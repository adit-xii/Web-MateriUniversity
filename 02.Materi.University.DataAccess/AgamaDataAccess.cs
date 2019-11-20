using _03.Materi.University.ViewModel;
using _04.Materi.University.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Materi.University.DataAccess
{
    public class AgamaDataAccess
    {
        public static string Message = string.Empty;
        public static List<AgamaViewModel> GetListAll()
        {
            List<AgamaViewModel> result = new List<AgamaViewModel>();
            using (var db = new DB_UniversityEntities())
            {
                result = (from attributs in db.tbl_m_agama
                          select new AgamaViewModel
                          {
                              id_agama_pk = attributs.id_agama_pk,
                              kode_agama = attributs.kode_agama,
                              deskripsi = attributs.deskripsi,
                              is_active = attributs.is_active,
                              created_by = attributs.created_by,
                              created_date = attributs.created_date,
                              updated_by = attributs.updated_by,
                              updated_date = attributs.updated_date
                          }
                          ).ToList();
            }
            return result;
        }

        public static AgamaViewModel GetDetailsByid(int id)
        {
            AgamaViewModel result = new AgamaViewModel();
            using (var db = new DB_UniversityEntities())
            {
                result = (from attributs in db.tbl_m_agama
                          where attributs.id_agama_pk == id
                          select new AgamaViewModel
                          {
                              id_agama_pk = attributs.id_agama_pk,
                              kode_agama = attributs.kode_agama,
                              deskripsi = attributs.deskripsi,
                              is_active = attributs.is_active,
                              created_by = attributs.created_by,
                              created_date = attributs.created_date,
                              updated_by = attributs.updated_by,
                              updated_date = attributs.updated_date
                          }).FirstOrDefault();
            }
            return result;
        }
        public static bool Insert(AgamaViewModel model)
        {
            bool result = true;

            try
            {
                using (var db = new DB_UniversityEntities())
                {
                    tbl_m_agama attributs = new tbl_m_agama();
                    attributs.deskripsi = model.deskripsi;
                    attributs.is_active = model.is_active;
                    attributs.created_by = model.created_by;
                    attributs.created_date = model.created_date;
                    attributs.updated_by = model.updated_by;
                    attributs.updated_date = model.updated_date;
                    attributs.kode_agama = model.kode_agama;

                    db.tbl_m_agama.Add(attributs);
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
        public static bool Update(AgamaViewModel model)
        {
            bool result = true;
            try
            {
                using (var db = new DB_UniversityEntities())
                {
                    tbl_m_agama attributs = db.tbl_m_agama.Where(o => o.id_agama_pk == model.id_agama_pk).FirstOrDefault();

                    if (attributs != null)
                    {
                        attributs.kode_agama = model.kode_agama;
                        attributs.deskripsi = model.deskripsi;
                        attributs.is_active = model.is_active;
                        attributs.updated_by = model.updated_by;
                        attributs.updated_date = model.updated_date;
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
        public static bool Delete(AgamaViewModel model)
        {
            bool result = true;
            try
            {
                using (var db = new DB_UniversityEntities())
                {
                    tbl_m_agama attributs = db.tbl_m_agama.Where(o => o.id_agama_pk == model.id_agama_pk).FirstOrDefault();

                    if (attributs != null)
                    {
                        attributs.is_active = model.is_active;
                        attributs.updated_by = model.updated_by;
                        attributs.updated_date = model.updated_date;
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
