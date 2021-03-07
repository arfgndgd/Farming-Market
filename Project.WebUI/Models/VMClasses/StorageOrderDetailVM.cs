using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebUI.Models.VMClasses
{
    public class StorageOrderDetailVM
    {
        public List<Storage> Storages { get; set; }
        public StorageOrderDetail StorageOrderDetail { get; set; }
        public List<StorageOrderDetail> StorageOrderDetails { get; set; }
        public List<StorageOrder> StorageOrders { get; set; }

       
    }
}