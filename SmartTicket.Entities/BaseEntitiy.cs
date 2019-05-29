using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTicket.Entities
{
    public  class BaseEntitiy
    {
        public int Id { get; set; }

        [DisplayName("Oluşturulma Tarihi")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreateDate { get; set; }

        [DisplayName("Oluşturan Kullanıcı")]
        public string CreatedBy { get; set; }

        [DisplayName("Güncellenme Tarihi")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime UpdateDate { get; set; }

        [DisplayName("Güncelleyen Kullanıcı")]
        public string UpdatedBy { get; set; }
    }
}
