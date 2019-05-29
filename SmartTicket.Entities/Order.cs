using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTicket.Entities
{
    public class Order : BaseEntitiy
    {

        public Guid TicketQR { get; set; }
        
        [DisplayName("Kullanıcı")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        [DisplayName("Kullanıcı")]
        public virtual User User { get; set; }


        [DisplayName("Etkinlik")]
        public int ActivityId { get; set; }
        [ForeignKey("ActivityId")]
        [DisplayName("Etkinlik")]
        public virtual Activity Activity { get; set; }
    }
}
