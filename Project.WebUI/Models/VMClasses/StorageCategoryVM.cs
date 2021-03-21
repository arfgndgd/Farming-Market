using PagedList;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebUI.Models.VMClasses
{
    public class StorageCategoryVM
    {
        public StorageCategory StorageCategory { get; set; }

        public List<StorageCategory> StorageCategories { get; set; }

        public Storage Storage { get; set; }

        public List<Storage> Storages { get; set; }

        public IPagedList<Storage> PagedStorages { get; set; }
    }
}