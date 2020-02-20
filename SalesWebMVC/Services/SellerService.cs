using System;
using System.Collections.Generic;
using System.Linq;
using SalesWebMVC.Data;
using SalesWebMVC.Models;

namespace SalesWebMVC.Services {
    public class SellerService {
        //context
        private readonly SalesWebMVCContext _context;

        public SellerService(SalesWebMVCContext context) {
            _context = context;
        }

        public List<Seller> FindAll() {
            return _context.Seller.ToList();
        }
        public void Insert(Seller obj) {
            obj.Department = _context.Department.First();
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
