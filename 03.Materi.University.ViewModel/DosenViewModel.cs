using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Materi.University.ViewModel
{
    public class DosenViewModel
    {
        public long id_dosen_pk { get; set; }

        [Required]
        [Display(Name = "Kode")]
        public string kode_dosen { get; set; }

        [Required]
        [Display(Name = "Nama")]
        public string nama_dosen { get; set; }

        [Display(Name = "Program Studi")]
        public int id_jurusan_fk { get; set; }

        [Display(Name = "Status Karyawan")]
        public int id_type_dosen_fk { get; set; }

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


        /* Jurusan dan Jenis karyawan*/
        public string program_studi { get; set; }
        public string status_karyawan { get; set; }
    }

    public class PagingModel_Jurusan
    {
        public PagingModel_Jurusan(int totalItems, int? page, int pageSize = 10)
        {
            // calculate total, start and end pages
            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            var currentPage = page != null ? (int)page : 1;
            var startPage = currentPage - 5;
            var endPage = currentPage + 4;
            if (startPage <= 0)
            {
                endPage -= (startPage - 1);
                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
        }

        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
    }
}
