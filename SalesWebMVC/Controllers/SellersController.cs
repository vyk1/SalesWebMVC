using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;
using SalesWebMVC.Models;
using SalesWebMVC.Services.Exceptions;
using SalesWebMVC.Models.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System.Collections.Generic;

namespace SalesWebMVC.Controllers {
    public class SellersController : Controller {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;
        private readonly ILogger _logger;

        public SellersController(SellerService sellerService, DepartmentService departmentService, ILogger<SellersController> logger) {
            _logger = logger;
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index() {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create() {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller) {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var obj = _sellerService.FindByID(id.Value);
            if (obj == null) {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id) {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var obj = _sellerService.FindByID(id.Value);
            if (obj == null) {
                return NotFound();
            }
            return View(obj);
        }
        public IActionResult Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var obj = _sellerService.FindByID(id.Value);
            if (obj == null) {
                return NotFound();
            }

            List<Department> list = _departmentService.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = list };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller) {
            if (id != seller.Id) {
                return BadRequest();
            }
            try {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            } catch (NotFoundException) {
                return NotFound();
            } catch (DbConcurencyException) {
                return BadRequest();
            }
        }

    }
}