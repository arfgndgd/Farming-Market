using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class StorageCategory : BaseEntity
    {
        public string StorageCategoryName { get; set; }
        public string StorageDescription { get; set; }

        public StorageCategory()
        {
            Storages = new List<Storage>();
        }

        //Relational Properties
        public virtual List<Storage> Storages { get; set; }
    }
}
