using OnlineShop.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Admin()
        {
            ViewBag.ProductList = DAOClass.GenerateProductList();
            return View();
        }
        public ActionResult Cart(int id)
        {
            ViewBag.Cart = DAOClass.AddItemToCartList(id);

            return View();
        }

        public ActionResult Create ()
        {
            
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Products()
        {
            ViewBag.ProductList = DAOClass.GenerateProductList();            
            return View();
        }

        public ActionResult Search(string term)
        {
            ViewBag.SearchResults = DAOClass.SearchProductList(term);
            return View("Products");
        }
    }
}