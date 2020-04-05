using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebStore.DAL.Context;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = Role.Administrator)]
    public class HomeController : Controller
    {
        readonly IProductData _productData;
        readonly WebStoreContext _context;

        public HomeController(IProductData productData, WebStoreContext db)
        {
            _productData = productData;
            _context = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductList()
        {
            var products = _productData.GetProducts(new ProductFilter());
            return View(products);
        }

        public IActionResult Edit(int id)
        {
            return View();
        }

        public IActionResult RemoveAt(int id)
        {
            var product = _context.Products.First(o => o.Id == id);
            using (var transaction = _context.Database.BeginTransaction())
            {
                if (product != null)
                    _context.Products.Remove(product);
                _context.SaveChanges();
                transaction.Commit();
            }
            return RedirectToAction("ProductList");
        }
    }
}