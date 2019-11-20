using _03.Materi.University.ViewModel;
using _04.Materi.University.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Materi.University.DataAccess
{
    public class JurusanDataAccess
    {
        public static string Message = string.Empty;
        public static List<JurusanViewModel> GetListAll()
        {
            List<JurusanViewModel> result = new List<JurusanViewModel>();
            using (var db = new DB_UniversityEntities())
            {
                result = (from attributs in db.tbl_m_jurusan
                          select new JurusanViewModel
                          {
                              id_jurusan_pk = attributs.id_jurusan_pk,
                              kode_jurusan = attributs.kode_jurusan,
                              nama_jurusan = attributs.nama_jurusan,
                              is_active = attributs.is_active,
                              created_by = attributs.created_by,
                              created_date = attributs.created_date,
                              updated_by = attributs.updated_by,
                              updated_date = attributs.updated_date,
                              akreditasi = attributs.Akreditasi
                          }
                          ).ToList();
            }
            return result;
        }

        public static JurusanViewModel GetDetailsByid(int id)
        {
            JurusanViewModel result = new JurusanViewModel();
            using (var db = new DB_UniversityEntities())
            {
                result = (from attributs in db.tbl_m_jurusan
                          where attributs.id_jurusan_pk == id
                          select new JurusanViewModel
                          {
                              id_jurusan_pk = attributs.id_jurusan_pk,
                              kode_jurusan = attributs.kode_jurusan,
                              nama_jurusan = attributs.nama_jurusan,
                              is_active = attributs.is_active,
                              created_by = attributs.created_by,
                              created_date = attributs.created_date,
                              updated_by = attributs.updated_by,
                              updated_date = attributs.updated_date,
                              akreditasi = attributs.Akreditasi
                          }).FirstOrDefault();
            }
            return result;
        }
        public static bool Insert(JurusanViewModel model)
        {
            bool result = true;

            try
            {
                using (var db = new DB_UniversityEntities())
                {
                    tbl_m_jurusan attributs = new tbl_m_jurusan();
                    attributs.nama_jurusan = model.nama_jurusan;
                    attributs.is_active = model.is_active;
                    attributs.created_by = model.created_by;
                    attributs.created_date = model.created_date;
                    attributs.updated_by = model.updated_by;
                    attributs.updated_date = model.updated_date;
                    attributs.kode_jurusan = model.kode_jurusan;
                    attributs.Akreditasi = model.akreditasi;

                    db.tbl_m_jurusan.Add(attributs);
                    db.SaveChanges();
                }
            }
            catch (Exception hasError)
            {
                if (hasError.Message.ToLower().Contains("inner exception"))
                {
                    Message = hasError.InnerException.InnerException.Message;
                }
                else
                {
                    Message = hasError.Message;
                }
                result = false;
            }

            return result;
        }
        public static bool Update(JurusanViewModel model)
        {
            bool result = true;
            try
            {
                using (var db = new DB_UniversityEntities())
                {
                    tbl_m_jurusan attributs = db.tbl_m_jurusan.Where(o => o.id_jurusan_pk == model.id_jurusan_pk).FirstOrDefault();

                    if (attributs != null)
                    {
                        attributs.kode_jurusan = model.kode_jurusan;
                        attributs.nama_jurusan = model.nama_jurusan;
                        attributs.is_active = model.is_active;
                        attributs.updated_by = model.updated_by;
                        attributs.updated_date = model.updated_date;
                        attributs.Akreditasi = model.akreditasi;
                        db.SaveChanges();
                    }
                    else
                    {
                        result = false;
                        Message = "Categories not found!";
                    }
                }
            }
            catch (Exception hasError)
            {
                Message = hasError.Message;
                result = false;
            }
            return result;
        }

    }
}
