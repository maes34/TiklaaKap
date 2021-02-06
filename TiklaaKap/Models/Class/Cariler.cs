using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TiklaaKap.Models.Class
{
    public class Cariler
    {
        [Key]
        public int CariID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "Maksimum karakter limiti aşıldı.")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string CariAd { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(30, ErrorMessage = "Maksimum karakter limiti aşıldı.")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string CariSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CariSehir { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(150)]
        public string Adress { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string district { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(11)]
        public string phone { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string CariMail { get; set; }
        public ICollection<Sale> Sales { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public bool Information { get; set; }
    }
}