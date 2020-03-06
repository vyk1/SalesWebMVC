using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
using SalesWebMVC.Services.Exceptions;

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
            // inclusão de eager loading
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id) {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller seller) {
            if (!_context.Seller.Any(x => x.Id == seller.Id)) {
                throw new NotFoundException("Id not found");
            }

            try {
                _context.Update(seller);
                _context.SaveChanges();
                //respeitando a arquitetura mvc
                //exceções da camada de acesso a dados são capturadas pelo serviço e relancadas na forma de serviços pelo controlador
            } catch (DbConcurencyException e) {
                throw new DbConcurencyException(e.Message);
            }
        }
    }
}
