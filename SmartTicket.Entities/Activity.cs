using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTicket.Entities
{
    public class Activity:BaseEntitiy
    {
        [StringLength(200, ErrorMessage = "200 karakterden fazla giriş yaptınız.")]
        [Required(ErrorMessage = "Kategori Adı zorunludur.")]
        [DisplayName("Etkinlik Adı")]
        public string  Name { get; set; }

        [StringLength(400, ErrorMessage = "400 karakterden fazla giriş yaptınız.")]
        [Required(ErrorMessage = "Açıklama zorunludur.")]
        [DisplayName("Açıklama")]
        public string Description { get; set; }


        [DisplayName("Kategori")]
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [DisplayName("Kategori")]
        public virtual Category Category { get; set; }

        [DisplayName("Mekan")]
        public int? PlaceId { get; set; }
        [ForeignKey("PlaceId")]
        [DisplayName("Mekan")]
        public virtual Place Place { get; set; }

        [DisplayName("Firma")]
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        [DisplayName("Firma")]
        public virtual Company Company { get; set; }


        [DisplayName("Başlama Tarihi")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }

        [DisplayName("Bitiş Tarihi")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime FinishDate { get; set; }

        
        [Required(ErrorMessage = "Bilet Sayısı zorunludur.")]
        [DisplayName("Bilet Sayısı")]
        public int TicketCount { get; set; }

        
        [Required(ErrorMessage = "Bilet Fiyatı zorunludur.")]
        [DisplayName("Bilet Fiyatı")]
        public decimal TicketPrice { get; set; }

        //[StringLength(10, ErrorMessage = "10 karakterden fazla giriş yaptınız.")]
        //[Required(ErrorMessage = "Durum zorunludur.")]
        //[DisplayName("Durum")]
        //public Status Status { get; set; }                   //status class değil

        public virtual  ICollection<Order> Orders { get; set; }


    }
}
