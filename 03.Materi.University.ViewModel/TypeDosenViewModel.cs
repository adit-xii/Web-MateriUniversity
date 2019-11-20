using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Materi.University.ViewModel
{
    public class TypeDosenViewModel
    {
        public int id_type_dosen_pk { get; set; }

        [Required]
        [Display(Name = "Kode")]
        public string kode_type_dosen { get; set; }

        [Required]
        [Display(Name = "Deskripsi")]
        public string deskripsi { get; set; }

        [Display(Name = "Is Active")]
        public bool is_active { get; set; }

        [Display(Name = "Created By")]
        public string created_by { get; set; }

        [Display(Name = "Created Date")]
        public System.DateTime created_date { get; set; }

        [Display(Name = "Updated By")]
        public string updated_by { get; set; }

        [Display(Name = "Updated Date")]
        public System.DateTime updated_date { get; set; }
    }
}
