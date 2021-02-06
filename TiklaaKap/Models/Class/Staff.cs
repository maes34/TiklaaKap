using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TiklaaKap.Models.Class
{
    public class Staff
    {
        [Key]
        public int StaffID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string StaffName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string StaffSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250, ErrorMessage = "Maksimum değer aşıldı.")]
        public string StaffImage { get; set; }
        public ICollection<Sale> Sales { get; set; }

        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }

        public bool Information { get; set; }
    }
}