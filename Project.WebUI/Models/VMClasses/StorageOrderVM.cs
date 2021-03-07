using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebUI.Models.VMClasses
{
    public class StorageOrderVM
    {
        public List<Customer> Customers { get; set; }
        public List<StorageOrder> StorageOrders { get; set; }
        public StorageOrder StorageOrder { get; set; }
        public List<Shipper> Shippers { get; set; }
    }
}