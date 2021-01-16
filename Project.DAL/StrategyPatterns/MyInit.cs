using Project.DAL.ContextClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.StrategyPatterns
{
    public class MyInit:CreateDatabaseIfNotExists<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            //TODO: Admin işlemi nasıl yapılacak çünkü Employee kısmından yönetim istiyoruz
        }
    }
}
