using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotNet.Models
{
    public class Login
    {
        public int UserId {get; set;}
        [DisplayName("identifiant *")]
        [Required(ErrorMessage ="Identifiant obligatoire")]
        public string? UserName {get; set;}
        [DisplayName("Mot magique")]
        [DataType(DataType.Password)]
        public string? Password {get; set;}
        public string? Message {get; set;}
    }
}