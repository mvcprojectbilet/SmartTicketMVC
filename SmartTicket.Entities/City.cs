using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTicket.Entities
{
    public class City:BaseEntitiy
    {
        [StringLength(200, ErrorMessage = "200 karakterden fazla giriş yaptınız.")]
        [Required(ErrorMessage = "Şehir Adı zorunludur.")]
        [DisplayName("Şehir Adı")]
        public string Name { get; set; }

        public virtual ICollection<Place> Places { get; set; }


    }
}
