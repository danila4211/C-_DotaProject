using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            var product = _context.Product.First(x => x.Name == productName);

            return RedirectToAction("Product", product);
        }
        public IActionResult Privacy()
        {
            return View();
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
        [HttpGet]
        public IActionResult Autorization()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Product(int productId)
        {
            var product = _context.Product.FirstOrDefault(x => x.Id == productId);
            
            Cart cart = new Cart()
            {
                Product = product
            };

            _context.Carts.Add(cart);
            _context.SaveChanges();
            return View(product);
        }

        [HttpPost]
        public IActionResult Buy()
        {
            foreach (var cart in _context.Carts)
            {
                var product = _context.Product.First(x => x.Id == cart.ProductId);
                product.Count--;
            }
            _context.ClearCart();
            return RedirectToAction("Cart");
        }

        public IActionResult All_Items()
        {
            return View(_context);
        }
        [HttpPost]
        public IActionResult Registration(string login, string password) {
            if (login != null && password != null)
            {
                User user = new() { Name = login, Password = password };
                if(_context.Users.FirstOrDefault(user => user.Name == login && user.Password == password) == null)
                {
                    _context.Add(user);
                    _context.SaveChanges();
                    Program.ThisUser = user;
                    return RedirectToAction("Index");
                }
            }
            
            return View();
        
        }
        [HttpPost]
        public IActionResult Autorization(string login, string password)
        {
            if (login != null && password != null)
            {
                User user = _context.Users.FirstOrDefault(user => user.Name == login && user.Password == password);
                if (user != null)
                {
                    Program.ThisUser = user;
                    return RedirectToAction("Index");
                }
            }
            return View("Autorization");
        }
       
        [HttpPost]
        public IActionResult All_Items(string productName)
        {
            var product = _context.Product.First(x => x.Name == productName);
            return RedirectToAction("Product", product);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}