using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopUI.Models
{
    public class AddressModel
    {
        [Required]
        [StringLength(15,ErrorMessage = "Adres Başlığı 15 karakteri geçemez")]
        public string AddressTitle { get; set; }
        [Required]
        public string County { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string OpenAddress { get; set; }
    }
}
