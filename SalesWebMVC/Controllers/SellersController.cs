using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;


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
//        public IActionResult Create(Seller s) {
        public IActionResult Create(Seller s) {
            _logger.LogInformation(s.ToString());
            _logger.LogInformation("########################################################");
            //_sellerService.Insert(s);
            return RedirectToAction(nameof(Index));
            //return RedirectToAction("Index");
        }
    }
}