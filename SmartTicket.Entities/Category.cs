using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTicket.Entities
{
    public class Category:BaseEntitiy
    {
        [StringLength(200, ErrorMessage = "200 karakterden fazla giriş yaptınız.")]
        [Required(ErrorMessage = "Kategori Adı zorunludur.")]
        [DisplayName("Kategori Adı")]
        public string Name { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }



    }
}
