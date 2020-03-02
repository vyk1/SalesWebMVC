using System.Collections.Generic;

namespace SalesWebMVC.Models.ViewModels {
    public class SellerFormViewModel {
        public Seller Seller { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
    /*
    public override string ToString() {
        return "ToStr: " + Seller.toString() + ".";
    }
    */
}
