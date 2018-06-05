using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.DAO
{
    public class DAOClass
    {

        //This function adds the information to a user object and adds it to the DB
        public static void RegisterUser(User user)
        {
            OnlineShopEntities db = new OnlineShopEntities();
            db.Users.Add(user);
            db.SaveChanges();
        }

        //This function puts product items into a list
        public static  List<Product> GenerateProductList()
        {
            OnlineShopEntities db = new OnlineShopEntities();
            List<Product> products = db.Products.ToList();            
            return products;
        }

        //This adds a product to the session cart
        public static List<Product> AddItemToCartList(int id)
        {
            OnlineShopEntities db = new OnlineShopEntities();
            //check if cart alreay exists
            if (HttpContext.Current.Session["Cart"] == null)
            {
                //make a new list
                List<Product> cart = new List<Product>();
                //add this product to it
                cart.Add((from p in db.Products
                         where p.ProductID == id
                         select p).Single());
                //add the list to the session
                HttpContext.Current.Session.Add("Cart", cart);
                return cart;
            }
            else
            {
                //if the cart isn't empty
                List<Product> cart = (List<Product>)(HttpContext.Current.Session["Cart"]);
                //add book to cart
                cart.Add((from p in db.Products
                          where p.ProductID == id
                          select p).Single());
                return cart;
            }            
        }

        //This function searches the description of product listings
        public static List<Product> SearchProductList(string term)
        {
            OnlineShopEntities db = new OnlineShopEntities();
            List<Product> results = (from r in db.Products
                                where r.Description.Contains(term)
                                select r).ToList();
            return results;

        }
    }
}