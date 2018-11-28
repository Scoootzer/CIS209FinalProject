using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
/*
 * Hunter Carpenter & Raul Haro
 * Nov 12, 2018
 * Testing out the book's instructions and getting multiple tables to work.
 * May have to start from scratch (or heavily refactor) to change names all around
 * to make it easier to understand
 * Nov 19, 2018
 * Roles should be functional and mostly complete. Duplicate rows were found
 * in the database, they've been removed. Only the Owner may now see Cars and Trim.
 * Looked into forming LINQ queries that actually resemble SQL queries, should
 * be using these soon.
 * Nov 26, 2018
 * Added more dynamics to the form, experimenting with data manipulation. New button
 * and form states depending on role...
 */
namespace FinalProject {
    public partial class DisplayCarsTable : Form {

        private Roles ROLE;
        private Boolean fullClose = true;
        private Boolean hasTriedToDelete = false;
        //Tabs to remove based on the role set. Since enums
        //are 0, 1, 2, etc..., our ROLE will be used as the index.
        private string[][] TabsToRemove = {
            //Hide tabs for Customers
            new string[5] {"tab_Customers", "tab_Cars", "tab_Reps", "tab_Trim", "tab_Sales" },
            //...for Reps
            new string[2] {"tab_Cars", "tab_Reps"},
            //...for Owner (nothing to hide, really)
            new string[0] { }
        };

        private Dictionary<string, Roles> permissions = new Dictionary<string, Roles>();

        public DisplayCarsTable(Roles ROLE) {
            InitializeComponent();
            this.ROLE = ROLE;
            permissions.Add("deleteItem", Roles.OWNER);
            permissions.Add("updateDb", Roles.OWNER);
            permissions.Add("addItem", Roles.OWNER);
        }

        public Boolean isFullClose() {
            return fullClose;
        }

        private FinalProjLib.NewCarDealerEntities dbctx = new FinalProjLib.NewCarDealerEntities();

        //Called on load of this form
        private void DisplayCarsTable_Load(object sender, EventArgs e) {

            //Hide specified tabs for the current role
            foreach (string i in TabsToRemove[(int)ROLE]) {
                tabControl.Controls[i].Dispose();
            }

            handleButtonStates();
            setFormState();

            //Execute queries for CUSTOMER roles and above
            if (ROLE >= Roles.CUSTOMER) {
                inventoryBindingSource.DataSource = Queries.baseInventoryQuery(dbctx).ToList();
                //Execute queries for REP roles and above
                if (ROLE >= Roles.REP) {
                    dbctx.customers.Load();
                    dbctx.trims.Load();

                    customerBindingSource.DataSource = dbctx.customers.Local;
                    saleBindingSource.DataSource = Queries.baseSalesQuery(dbctx).ToList();
                    trimBindingSource.DataSource = dbctx.trims.Local;
                    //Execute queries for OWNER roles and above
                    if (ROLE >= Roles.OWNER) {
                        dbctx.reps.Load();

                        basecarBindingSource.DataSource = Queries.baseCarQuery(dbctx).ToList();
                        repBindingSource.DataSource = dbctx.reps.Local;
                    }
                }
            }
        }

        //Change Role button
        //Closes this form, but allows the RoleSelection form to appear again
        private void button1_Click(object sender, EventArgs e) {
            this.fullClose = false;
            this.Close();
        }

        private void handleButtonStates() {
            Boolean canDeleteItem = ROLE >= permissions["deleteItem"];
            Boolean canUpdateDb = ROLE >= permissions["updateDb"];

            bn_CarDel.Enabled = 
                bn_CustDel.Enabled = 
                bn_InvDel.Enabled = 
                bn_RepDel.Enabled = 
                bn_SalesDel.Enabled = 
                bn_TrimDel.Enabled = canDeleteItem;

            btn_UpdateDb.Enabled = canUpdateDb;
        }

        private void setFormState() {
            Boolean canAddItem = ROLE >= permissions["addItem"];

            //Width of actual form
            this.Width = canAddItem ? 1065 : 831;
            //Width of the tab control
            tabControl.Width = canAddItem ? 1025 : 794;
            //Put groupboxes here containing info that the owner can see, such as the Add Rep box
            gb_AddRep.Enabled = canAddItem;
        }

        private void DeleteItem(object sender, EventArgs e) {
            if (!hasTriedToDelete) {
                hasTriedToDelete = true;
                MessageBox.Show("Deletion will not take effect until you click the \"Update Database\" button. This message will not appear again.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_UpdateDb_Click(object sender, EventArgs e) {
            if (ROLE >= permissions["updateDb"])
                dbctx.SaveChanges();
        }

        private void button2_Click(object sender, EventArgs e) {
            /*
             * All of this is just some random testing stuff
             */
            string last = textBox1.Text,
                first = textBox2.Text;
            int id = 3;
            FinalProjLib.rep Rep = (from i in dbctx.reps
                                    where i.repID == id
                                    select i).SingleOrDefault();
            Rep.lastname = last;
            Rep.firstname = first;
            if (Rep.Equals(null)) {
                Console.WriteLine("Rep not found");//repBindingSource.Add(new FinalProjLib.rep { repID = 1000, firstname = first, lastname = last });
            }
        }

        private void repDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
            //Wanted to get row info before the delete button gets rid of it, but it doesn't work?
            foreach (DataGridViewRow i in repDataGridView.SelectedCells) {
                if (i.Selected) {
                    Console.WriteLine(i.Cells["ID"]);
                    /*FinalProjLib.sale Sale = (from s in dbctx.sales
                                              where s.repID == i.)*/
                }
            }
        }

        // Query the basecar table
        private void cbxCarsQueries_SelectedIndexChanged(object sender, EventArgs e) {
            basecarBindingSource.DataSource = Queries.carsQueryList(dbctx, cbxCarsQueries).ToList();
        }

        // Query the customer table
        private void cbxCustomersQueries_SelectedIndexChanged(object sender, EventArgs e) {
            customerBindingSource.DataSource = Queries.customersQueryList(dbctx, cbxCustomersQueries).ToList();
        }

        // Query the inventory table
        private void cbxInventoryQueries_SelectedIndexChanged(object sender, EventArgs e) {
            inventoryBindingSource.DataSource = Queries.inventoryQueriesList(dbctx, cbxInventoryQueries).ToList();
        }

        // Query the sale table
        private void cbxSalesQueries_SelectedIndexChanged(object sender, EventArgs e) {
            saleBindingSource.DataSource = Queries.salesQueryList(dbctx, cbxSalesQueries).ToList();
        }

        // Query the trim table
        private void cbxTrimsQueries_SelectedIndexChanged(object sender, EventArgs e) {
            trimBindingSource.DataSource = Queries.trimsQueryList(dbctx, cbxTrimsQueries).ToList();
        }
    }
}
