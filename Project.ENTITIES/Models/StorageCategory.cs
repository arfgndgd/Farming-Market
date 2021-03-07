using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class StorageCategory : BaseEntity
    {
        //Customer Storage classları ile ilgilidir. Yalnızca elden satış için açılmıştır. Erişimi Areas içinden ve WFA versiyonu içindir. AppUser Customer ve Product Storage ürünleri farklıdır. 

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
