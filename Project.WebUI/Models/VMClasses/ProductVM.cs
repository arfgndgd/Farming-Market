using PagedList;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebUI.Models.VMClasses
{
    //PAVM ile benzer ama PAVM classında alışveriş için sayfalama yapar. Benzer class gibidir ama farklıdır
    public class ProductVM
    {
        public List<Product> Products { get; set; }
        public Product Product { get; set; }
        public IPagedList<Product> PagedProducts { get; set; }
        public List<Category> Categories { get; set; }
        public List<Supplier> Suppliers { get; set; }
    }
}