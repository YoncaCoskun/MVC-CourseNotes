using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCDersiValidation.Models
{
    public class ContactModel
    {
        [Required]
        [Display(Name = "Adı ve Soyadı")]
        [MaxLength(100)]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "E-Posta")]
        [MaxLength(100)]
        public string Email { get; set; }
         [Required]
         [Display(Name = "Cep Telefonu")]
         [MaxLength(25)]
        public string MobilePhone { get; set; }
         [Required]
         [Display(Name = "Mesaj")]
         [MaxLength(500)]
        public string Message { get; set; }
    }
}