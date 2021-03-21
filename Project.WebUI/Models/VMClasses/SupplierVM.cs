using PagedList;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebUI.Models.VMClasses
{
    public class SupplierVM
    {
        public Supplier Supplier { get; set; }

        public List<Supplier> Suppliers { get; set; }

        public Product Product { get; set; }

        public List<Product> Products { get; set; }

        public Storage Storage { get; set; }

        public List<Storage> Storages { get; set; }

        public IPagedList<Storage> PagedStorages { get; set; }

        public IPagedList<Product> PagedProducts { get; set; }
    }
}