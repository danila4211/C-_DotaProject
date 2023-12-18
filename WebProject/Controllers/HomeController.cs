using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class HomeController : Controller
    {
        private MainContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, MainContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_context);
        }

        [HttpPost]
        public IActionResult Index(string productName)
        {
            var product = _context.Products.First(x => x.Name == productName);

            return RedirectToAction("Product", product);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public decimal Sum(Cart cart)
        {
            decimal total = (from Product in _context.Products where Product.Id == cart.ProductID select Product.Cost).Sum(); return total;
        }

        [HttpGet]
        public IActionResult Cart()
        {
            return View(_context);
        }
        public IActionResult Product(Product product)
        {
            return View(product);
        }

        [HttpPost]
        public IActionResult Product(int productId)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == productId);
            Cart cart = new Cart()
            {
                ProductID = productId
            };

            _context.Carts.Add(cart);
            _context.SaveChanges();
            return View(product);
        }

        public IActionResult All_Items()
        {
            return View(_context);
        }
       
        [HttpPost]
        public IActionResult All_Items(string productName)
        {
            var product = _context.Products.First(x => x.Name == productName);
            return RedirectToAction("Product", product);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}