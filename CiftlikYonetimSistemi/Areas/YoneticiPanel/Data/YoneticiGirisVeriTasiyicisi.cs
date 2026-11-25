using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CiftlikYonetimSistemi.Areas.YoneticiPanel.Data
{
    
    public class YoneticiGirisVeriTasiyicisi
    {
        [Required(ErrorMessage = "Mail Boş Bırakılamaz")]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre Boş Bırakılamaz")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Şifre 8 - 20 karakter arası olmalıdır")]
        public string Sifre { get; set; }
    }
}