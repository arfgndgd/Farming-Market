using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class AppUserMap : BaseMap<AppUser>
    {
        public AppUserMap()
        {
            HasOptional(x => x.UserProfile).WithRequired(x => x.AppUser);
            //HasOptional(x => x.Employee).WithRequired(x => x.AppUser);
        }
    }
}
