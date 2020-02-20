using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;
using SalesWebMVC.Models;

namespace SalesWebMVC.Controllers {
    public class SellersController : Controller {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService) {
            _sellerService = sellerService;
        }

        public IActionResult Index() {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller s) { 
            _sellerService.Insert(s);
            return RedirectToAction(nameof(Index));
            //return RedirectToAction("Index");
        }
    }
}