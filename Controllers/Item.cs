using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMaduraiCateringService.Models;

namespace WebMaduraiCateringService.Controllers
{
    public class Item
    {
        private Product pr = new Product();

    
        private int quantity;

      

        public Item()
        {}
        public Item(Product p, int quantity)
        {
            this.Pr = p;
            this.Quantity = quantity;
        }

        public Product Pr { get => pr; set => pr = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}