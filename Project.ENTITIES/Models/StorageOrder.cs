using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class StorageOrder:BaseEntity
    {
        //Customer Storage classları ile ilgilidir. Yalnızca elden satış için açılmıştır. Erişimi Areas içinden ve WFA versiyonu içindir. AppUser Customer ve Product Storage ürünleri farklıdır. 

        public string ShippedAddress { get; set; }
        public string ShippedCity { get; set; }
        public string ShippedCountry { get; set; }
        public int? ShipperID { get; set; }

        public int? CustomerID { get; set; }

        //Relational Properties
        public virtual Customer Customer { get; set; } //ELden satış için açıılmıştır.
        public virtual List<StorageOrderDetail> StorageOrderDetails { get; set; }
        public virtual Shipper Shipper { get; set; }

    }
}
