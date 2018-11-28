using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FinalProject {
    public partial class RoleSelection : Form {
        public RoleSelection() {
            InitializeComponent();
        }

        private void setCtrlStates(Boolean state) {
            foreach (Control i in this.Controls) {
                if (Regex.IsMatch(i.Name, "^radio_", RegexOptions.IgnoreCase))
                    i.Enabled = state;
            }
            button1.Enabled = state;
        }

        private void button1_Click(object sender, EventArgs e) {
            Roles role = Roles.CUSTOMER;
            Boolean valid = true;
            if (radio_Rep.Checked) {
                role = Roles.REP;
            } else if (radio_Owner.Checked) {
                role = Roles.OWNER;
            } else if (!radio_Customer.Checked) {
                valid = false;
            }
            if (valid) {
                button1.Text = "Waiting for database...";
                setCtrlStates(false);
                Form dealership = new DisplayCarsTable(role);
                dealership.Load += new EventHandler(Hide);
                dealership.FormClosing += new FormClosingEventHandler(Close);
                dealership.Show();
            }
        }

        private void Hide(object sender, EventArgs e) {
            this.Hide();
        }

        private void Close(object sender, FormClosingEventArgs e) {
            if (((DisplayCarsTable)sender).isFullClose()) {
                this.Close();
            } else {
                button1.Text = "Confirm Selection";
                setCtrlStates(true);
                this.Show();
            }
        }
    }


    public enum Roles {
        CUSTOMER,
        REP,
        OWNER
    }
}
