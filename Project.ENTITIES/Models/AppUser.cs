using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class AppUser:BaseEntity
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre adı boş geçilemez")]
        public string Password { get; set; }

        //[NotMapped] //veritabanında efektif olmaz 
        //[Compare("Password")]
        [Required(ErrorMessage = "Şifre adı boş geçilemez")]
        [Compare("Password",ErrorMessage ="Aynı değil")]
        public string ConfirmPassword { get; set; }
        public Guid ActivationCode { get; set; }
        public bool Active { get; set; }
        public string Email { get; set; }
        public UserRole URole { get; set; }
        public bool RememberMe { get; set; }


        public AppUser()
        {
            URole = UserRole.Member;
            ActivationCode = Guid.NewGuid();
        }

        //Relational Properties
        public virtual UserProfile UserProfile { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
