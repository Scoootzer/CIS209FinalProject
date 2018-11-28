using System.Linq;
using FinalProjLib;
using System.Windows.Forms;
using System.Collections.Generic;
using System;

namespace FinalProject {
    static class Queries {

        public static IQueryable<dynamic> baseInventoryQuery(NewCarDealerEntities dbctx) {
            return from i in dbctx.inventories
                         join b in dbctx.basecars
                            on i.basecarID equals b.basecarID
                         join t in dbctx.trims
                             on i.trimID equals t.trimID
                         orderby i.basecarID
                         orderby b.basecarmodel
                         orderby i.inventoryID
                         where (bool)!b.sold
                   select new { i.inventoryID, b.basecarID, b.basecarmodel, trim = t.trimtype, msrp = b.basecarmodelmsrp };
        }

        public static IQueryable<dynamic> baseCarQuery(NewCarDealerEntities dbctx) {
            return from b in dbctx.basecars
                   join i in dbctx.inventories
                        on b.basecarID equals i.basecarID into invcars
                   from ic in invcars.DefaultIfEmpty()
                   orderby b.basecarID
                   orderby b.basecarmodel
                   orderby b.sold ascending
                   select new {
                       b.basecarID,
                       b.vin,
                       b.basecarmodel,
                       b.basecarmodelyear,
                       b.basecarmodelfactorycost,
                       b.basecarmodelmsrp,
                       sold = (bool)b.sold ? "Yes" : "No",
                       ic.inventoryID
                    };
                        
        }

        public static IQueryable<dynamic> baseSalesQuery(NewCarDealerEntities dbctx) {
            return from s in dbctx.sales
                   join c in dbctx.customers
                    on s.customerID equals c.customerID
                   join r in dbctx.reps
                    on s.repID equals r.repID
                   select new { s.salesID, s.inventoryID, custLast = c.lastname, custFirst = c.firstname, repLast = r.lastname, repFirst = r.firstname, s.saledate};
        }
        // These queries still need to be modified to work with this application smoothly
        // List of queries for the basecar table
        public static IQueryable<dynamic> carsQueryList(NewCarDealerEntities dbctx, ComboBox cbx) {
            switch (cbx.SelectedIndex) {
                case 0:
                    return
                        from c in dbctx.basecars
                        orderby c.basecarID
                        select new { c.basecarID, c.vin, c.basecarmodel, c.basecarmodelfactorycost, c.basecarmodelmsrp, c.basecarmodelyear, c.sold };
                case 1:
                    return
                        from c in dbctx.basecars
                        orderby c.basecarmodelfactorycost
                        select new { c.basecarID, c.vin, c.basecarmodel, c.basecarmodelfactorycost, c.basecarmodelmsrp, c.basecarmodelyear, c.sold };
                case 2:
                    return
                        from c in dbctx.basecars
                        orderby c.basecarmodelfactorycost descending
                        select new { c.basecarID, c.vin, c.basecarmodel, c.basecarmodelfactorycost, c.basecarmodelmsrp, c.basecarmodelyear, c.sold };
                case 3:
                    return
                        from c in dbctx.basecars
                        orderby c.sold
                        select new { c.basecarID, c.vin, c.basecarmodel, c.basecarmodelfactorycost, c.basecarmodelmsrp, c.basecarmodelyear, c.sold };
                default:
                    return new List<dynamic>().AsQueryable();
            }
        }

        // List of queries for the customers table
        public static IQueryable<dynamic> customersQueryList(NewCarDealerEntities dbctx, ComboBox cbx) {
            switch (cbx.SelectedIndex) {
                case 0:
                    return
                        from c in dbctx.customers
                        orderby c.customerID
                        select new { c.customerID, c.lastname, c.firstname, c.sales };
                case 1:
                    return
                        from c in dbctx.customers
                        orderby c.lastname
                        select new { c.customerID, c.lastname, c.firstname, c.sales };
                case 2:
                    return
                        from c in dbctx.customers
                        orderby c.lastname descending
                        select new { c.customerID, c.lastname, c.firstname, c.sales };
                default:
                    return new List<dynamic>().AsQueryable();
            }
        }

        // List of queries for the inventory table
        public static IQueryable<dynamic> inventoryQueriesList(NewCarDealerEntities dbctx, ComboBox cbx) {
            switch (cbx.SelectedIndex) {
                case 0:
                    return
                        from i in dbctx.inventories
                        join b in dbctx.basecars on i.basecarID equals b.basecarID
                        join t in dbctx.trims on i.trimID equals t.trimID
                        select new { i.inventoryID, i.basecarID, b.basecarmodel, trims = t.trimtype, b.basecarmodelmsrp };
                case 1:
                    return queryInventory(dbctx, "CHEVY EQUINOX");
                case 2:
                    return queryInventory(dbctx, "CHEVY BLAZER");
                case 3:
                    return queryInventory(dbctx, "CHEVY TRAVERSE");
                case 4:
                    return queryInventory(dbctx, "CHEVY TRAX");
                case 5:
                    return
                        from i in dbctx.inventories
                        join b in dbctx.basecars on i.basecarID equals b.basecarID
                        join t in dbctx.trims on i.trimID equals t.trimID
                        orderby b.basecarmodelmsrp
                        select new { i.inventoryID, i.basecarID, b.basecarmodel, trims = t.trimtype, b.basecarmodelmsrp };
                case 6:
                    return
                        from i in dbctx.inventories
                        join b in dbctx.basecars on i.basecarID equals b.basecarID
                        join t in dbctx.trims on i.trimID equals t.trimID
                        orderby b.basecarmodelmsrp descending
                        select new { i.inventoryID, i.basecarID, b.basecarmodel, trims = t.trimtype, b.basecarmodelmsrp };
                default:
                    return new List<dynamic>().AsQueryable();
            }
        }

        // List of queries for the sales table
        public static IQueryable<dynamic> salesQueryList(NewCarDealerEntities dbctx, ComboBox cbx) {
            switch (cbx.SelectedIndex) {
                case 0:
                    return
                        from s in dbctx.sales
                        orderby s.salesID
                        select new { s.salesID, s.inventoryID, s.customerID, s.repID, s.saledate, s.inventory, s.customer, s.rep };
                case 1:
                    return
                        from s in dbctx.sales
                        orderby s.inventoryID
                        select new { s.salesID, s.inventoryID, s.customerID, s.repID, s.saledate, s.inventory, s.customer, s.rep };
                case 2:
                    return
                        from s in dbctx.sales
                        orderby s.customerID
                        select new { s.salesID, s.inventoryID, s.customerID, s.repID, s.saledate, s.inventory, s.customer, s.rep };
                case 3:
                    return
                        from s in dbctx.sales
                        orderby s.repID
                        select new { s.salesID, s.inventoryID, s.customerID, s.repID, s.saledate, s.inventory, s.customer, s.rep };
                default:
                    return new List<dynamic>().AsQueryable();
            }
        }

        // List of queries for the trims table
        public static IQueryable<dynamic> trimsQueryList(NewCarDealerEntities dbctx, ComboBox cbx) {
            switch (cbx.SelectedIndex) {
                case 0:
                    return
                        from t in dbctx.trims
                        orderby t.trimID
                        select new { t.trimID, t.trimtype, t.trimtypefactorycost, t.trimtypemsrp, t.trimtypeyear, t.inventories };
                case 1:
                    return
                        from t in dbctx.trims
                        orderby t.trimtypefactorycost
                        select new { t.trimID, t.trimtype, t.trimtypefactorycost, t.trimtypemsrp, t.trimtypeyear, t.inventories };
                case 2:
                    return
                        from t in dbctx.trims
                        orderby t.trimtypefactorycost descending
                        select new { t.trimID, t.trimtype, t.trimtypefactorycost, t.trimtypemsrp, t.trimtypeyear, t.inventories };
                case 3:
                    return
                        from t in dbctx.trims
                        orderby t.trimtype
                        select new { t.trimID, t.trimtype, t.trimtypefactorycost, t.trimtypemsrp, t.trimtypeyear, t.inventories };
                default:
                    return new List<dynamic>().AsQueryable();
            }
        }

        // Method to reuse code for some inventories queries
        private static dynamic queryInventory(NewCarDealerEntities dbctx, string carmodel) {
            return
                from i in dbctx.inventories
                join b in dbctx.basecars on i.basecarID equals b.basecarID
                join t in dbctx.trims on i.trimID equals t.trimID
                where b.basecarmodel == carmodel
                select new { i.inventoryID, i.basecarID, b.basecarmodel, trims = t.trimtype, b.basecarmodelmsrp };
        }
    }
}
