using PagedList;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebUI.Models.VMClasses
{
    public class PAVM
    {
        //Ürünlerin listelenirken sayfalandırılması ile ilgili sınıf(PagedList)
        public Product Product { get; set; }

        public List<Product> Products { get; set; }

        public List<Category> Categories { get; set; }

        public IPagedList<Product> PagedProducts { get; set; }

        public Blog Blog { get; set; }

        public List<Blog> Blogs { get; set; }

        public IPagedList<Blog> PagedBlogs { get; set; }


    }
}