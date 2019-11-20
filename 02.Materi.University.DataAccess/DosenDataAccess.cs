using _03.Materi.University.ViewModel;
using _04.Materi.University.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Materi.University.DataAccess
{
    public class DosenDataAccess
    {
        public static string Message = string.Empty;
        public static List<DosenViewModel> GetListAll()
        {
            List<DosenViewModel> result = new List<DosenViewModel>();
            using (var db = new DB_UniversityEntities())
            {
                result = (from attributs in db.tbl_m_dosen
                          join b in db.tbl_m_jurusan on attributs.id_jurusan_fk equals b.id_jurusan_pk
                          join c in db.tbl_m_type_dosen on attributs.id_type_dosen_fk equals c.id_type_dosen_pk
                          select new DosenViewModel
                          {
                              id_dosen_pk = attributs.id_dosen_pk,
                              kode_dosen = attributs.kode_dosen,
                              nama_dosen = attributs.nama_dosen,
                              id_jurusan_fk = attributs.id_jurusan_fk,
                              id_type_dosen_fk = attributs.id_type_dosen_fk,
                              is_active = attributs.is_active,
                              created_by = attributs.created_by,
                              created_date = attributs.created_date,
                              updated_by = attributs.updated_by,
                              updated_date = attributs.updated_date,
                              program_studi = b.nama_jurusan,
                              status_karyawan = c.deskripsi
                          }
                          ).ToList();
            }
            return result;
        }
        public static List<DosenViewModel> GetListAll(string paramSearch, int paramAsc, int paramDesc, int paramPage, int paramPageSize)
        {
            List<DosenViewModel> result = new List<DosenViewModel>();
            using (var db = new DB_UniversityEntities())
            {
                IQueryable<DosenViewModel> query;

                /* pengurutan / sorting */
                if (paramAsc == 1)
                {
                    query = (from attributs in db.tbl_m_dosen
                             join b in db.tbl_m_jurusan on attributs.id_jurusan_fk equals b.id_jurusan_pk
                             join c in db.tbl_m_type_dosen on attributs.id_type_dosen_fk equals c.id_type_dosen_pk
                             where attributs.kode_dosen.ToLower().Trim().Contains(paramSearch) ||
                             attributs.nama_dosen.ToLower().Trim().Contains(paramSearch)
                             orderby attributs.kode_dosen ascending
                             select new DosenViewModel
                             {
                                 id_dosen_pk = attributs.id_dosen_pk,
                                 kode_dosen = attributs.kode_dosen,
                                 nama_dosen = attributs.nama_dosen,
                                 id_jurusan_fk = attributs.id_jurusan_fk,
                                 id_type_dosen_fk = attributs.id_type_dosen_fk,
                                 is_active = attributs.is_active,
                                 created_by = attributs.created_by,
                                 created_date = attributs.created_date,
                                 updated_by = attributs.updated_by,
                                 updated_date = attributs.updated_date,
                                 program_studi = b.nama_jurusan,
                                 status_karyawan = c.deskripsi
                             }).Skip(paramPage).Take(paramPageSize);
                }
                else
                {
                    query = (from attributs in db.tbl_m_dosen
                             join b in db.tbl_m_jurusan on attributs.id_jurusan_fk equals b.id_jurusan_pk
                             join c in db.tbl_m_type_dosen on attributs.id_type_dosen_fk equals c.id_type_dosen_pk
                             where attributs.kode_dosen.ToLower().Trim().Contains(paramSearch) ||
                             attributs.nama_dosen.ToLower().Trim().Contains(paramSearch)
                             orderby attributs.kode_dosen descending
                             select new DosenViewModel
                             {
                                 id_dosen_pk = attributs.id_dosen_pk,
                                 kode_dosen = attributs.kode_dosen,
                                 nama_dosen = attributs.nama_dosen,
                                 id_jurusan_fk = attributs.id_jurusan_fk,
                                 id_type_dosen_fk = attributs.id_type_dosen_fk,
                                 is_active = attributs.is_active,
                                 created_by = attributs.created_by,
                                 created_date = attributs.created_date,
                                 updated_by = attributs.updated_by,
                                 updated_date = attributs.updated_date,
                                 program_studi = b.nama_jurusan,
                                 status_karyawan = c.deskripsi
                             }).Skip(paramPage).Take(paramPageSize);
                }

                result = query.ToList();

            }
            return result;
        }
        public static int GetCountData(string paramSearch)
        {
            int countData = 0;

            using (var db = new DB_UniversityEntities())
            {
                countData = (db.tbl_m_dosen.Count(a => a.kode_dosen.ToLower().Trim().Contains(paramSearch) || a.kode_dosen.ToLower().Trim().Contains(paramSearch)));
            }

            return countData;
        }
        public static DosenViewModel GetDetailsByid(int id)
        {
            DosenViewModel result = new DosenViewModel();
            using (var db = new DB_UniversityEntities())
            {
                result = (from attributs in db.tbl_m_dosen
                          join b in db.tbl_m_jurusan on attributs.id_jurusan_fk equals b.id_jurusan_pk
                          join c in db.tbl_m_type_dosen on attributs.id_type_dosen_fk equals c.id_type_dosen_pk
                          where attributs.id_dosen_pk == id
                          select new DosenViewModel
                          {
                              id_dosen_pk = attributs.id_dosen_pk,
                              kode_dosen = attributs.kode_dosen,
                              nama_dosen = attributs.nama_dosen,
                              id_jurusan_fk = attributs.id_jurusan_fk,
                              id_type_dosen_fk = attributs.id_type_dosen_fk,
                              is_active = attributs.is_active,
                              created_by = attributs.created_by,
                              created_date = attributs.created_date,
                              updated_by = attributs.updated_by,
                              updated_date = attributs.updated_date,
                              program_studi = b.nama_jurusan,
                              status_karyawan = c.deskripsi
                          }).FirstOrDefault();
            }
            return result;
        }
        public static bool Insert(DosenViewModel model)
        {
            bool result = true;

            try
            {
                using (var db = new DB_UniversityEntities())
                {
                    tbl_m_dosen attributs = new tbl_m_dosen();
                    attributs.nama_dosen = model.nama_dosen;
                    attributs.id_jurusan_fk = model.id_jurusan_fk;
                    attributs.id_type_dosen_fk = model.id_type_dosen_fk;
                    attributs.is_active = model.is_active;
                    attributs.created_by = model.created_by;
                    attributs.created_date = model.created_date;
                    attributs.updated_by = model.updated_by;
                    attributs.updated_date = model.updated_date;
                    attributs.kode_dosen = model.kode_dosen;

                    db.tbl_m_dosen.Add(attributs);
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
        public static bool Update(DosenViewModel model)
        {
            bool result = true;
            try
            {
                using (var db = new DB_UniversityEntities())
                {
                    tbl_m_dosen attributs = db.tbl_m_dosen.Where(o => o.id_dosen_pk == model.id_dosen_pk).FirstOrDefault();

                    if (attributs != null)
                    {
                        attributs.kode_dosen = model.kode_dosen;
                        attributs.nama_dosen = model.nama_dosen;
                        attributs.id_jurusan_fk = model.id_jurusan_fk;
                        attributs.id_type_dosen_fk = model.id_type_dosen_fk;
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
        public static bool Delete(DosenViewModel model)
        {
            bool result = true;
            try
            {
                using (var db = new DB_UniversityEntities())
                {
                    tbl_m_dosen attributs = db.tbl_m_dosen.Where(o => o.id_dosen_pk == model.id_dosen_pk).FirstOrDefault();

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
