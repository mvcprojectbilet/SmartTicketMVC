using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTicket.Entities
{
    public class User:BaseEntitiy
    {
        [StringLength(200, ErrorMessage = "200 karakterden fazla giriş yaptınız.")]
        [Required(ErrorMessage = "Kullanıcı Adı zorunludur.")]
        [DisplayName("Kullanıcı Adı")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [StringLength(16, ErrorMessage = "En az 8, en fazla 16 karakter içerebilir.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre Onaylama zorunludur.")]
        [StringLength(16, ErrorMessage = "En az 8, en fazla 16 karakter içerebilir.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Şifre ve Şifre Onaylama aynı değil.")]
        public string ConfirmPassword { get; set; }


        [DisplayName("Rol")]
        public Role Role { get; set; }

        [StringLength(200, ErrorMessage = "200 karakterden fazla giriş yaptınız.")]
        [Required(ErrorMessage = "Adı zorunludur.")]
        [DisplayName("Adı")]
        public string Name { get; set; }

        [StringLength(200, ErrorMessage = "200 karakterden fazla giriş yaptınız.")]
        [Required(ErrorMessage = "Soyadı zorunludur.")]
        [DisplayName("Soyadı")]
        public string Surname { get; set; }

        [StringLength(15, ErrorMessage = "15 karakterden fazla giriş yaptınız.")]
        [Required(ErrorMessage = "Telefon zorunludur.")]
        [DisplayName("Telefon")]
        public string Phone { get; set; }

        [StringLength(100, ErrorMessage = "100 karakterden fazla giriş yaptınız.")]
        [Required(ErrorMessage = "Mail zorunludur.")]
        [DisplayName("Mail")]
        public string Mail { get; set; }

        
        [Required(ErrorMessage = "Cinsiyet zorunludur.")]
        [DisplayName("Cinsiyet")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Doğum Tarihi zorunludur.")]
        [DisplayName("Doğum Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDay { get; set; }

        public Guid? ActivedGuid { get; set; }

        [DisplayName("Durum")]
        public State State { get; set; }


        public virtual ICollection<Order> Orders { get; set; }


    }
}
