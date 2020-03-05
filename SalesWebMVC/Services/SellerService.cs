using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
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
        public void Insert(Seller seller) {
            seller.Department = _context.Department.First();
            _context.Add(seller);
            _context.SaveChanges();
        }
        
        public Seller FindByID(int id) {
            return _context.Seller.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id) {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
    }
}
