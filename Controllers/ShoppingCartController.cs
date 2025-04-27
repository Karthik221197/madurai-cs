using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMaduraiCateringService.Models;

namespace WebMaduraiCateringService.Controllers
{
    public class ShoppingCartController : Controller
    {
        private DatabaseFirstDbEntities de = new DatabaseFirstDbEntities();

        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        private int IsExisting(int id) 
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Pr.MenuId == id)
                    return i;
            return -1;

        }

        public ActionResult Delete(int MenuId)
        {
            int index = IsExisting(MenuId);
            List<Item> cart = (List <Item>) Session["cart"];
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return View("cart");
        }

        public ActionResult AddToCart(int MenuId)
        {
            if(Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item(de.Products.Find(MenuId), 1));
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = IsExisting(MenuId);
                if (index == -1)
                    cart.Add(new Item(de.Products.Find(MenuId), 1));
                else
                    cart[index].Quantity++;
                Session["cart"] = cart;
            }
            return View("Cart");
        }

        [HttpPost]
        public ActionResult Orders()
        {

            using(var de = new DatabaseFirstDbEntities())
            {
                foreach (var item in (List<Item>)Session["cart"])
                {
                    Order1 order = new Order1();



                    order.MenuName = item.Pr.MenuName;
                    order.Quantity = item.Quantity;
                    order.Price_Person = item.Pr.Price_Person;
                    



                    de.Order1.Add(order);
                    de.SaveChanges();
                }
            }


            return RedirectToAction("Form","Payment");
        }
    }
}