﻿using _03.Materi.University.ViewModel;
using _04.Materi.University.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Materi.University.DataAccess
{
    public class TypeDosenDataAccess
    {
        public static string Message = string.Empty;
        public static List<TypeDosenViewModel> GetListAll()
        {
            List<TypeDosenViewModel> result = new List<TypeDosenViewModel>();
            using (var db = new DB_UniversityEntities())
            {
                result = (from attributs in db.tbl_m_type_dosen
                          select new TypeDosenViewModel
                          {
                              id_type_dosen_pk = attributs.id_type_dosen_pk,
                              kode_type_dosen = attributs.kode_type_dosen,
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

        public static TypeDosenViewModel GetDetailsByid(int id)
        {
            TypeDosenViewModel result = new TypeDosenViewModel();
            using (var db = new DB_UniversityEntities())
            {
                result = (from attributs in db.tbl_m_type_dosen
                          where attributs.id_type_dosen_pk == id
                          select new TypeDosenViewModel
                          {
                              id_type_dosen_pk = attributs.id_type_dosen_pk,
                              kode_type_dosen = attributs.kode_type_dosen,
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
        public static bool Insert(TypeDosenViewModel model)
        {
            bool result = true;

            try
            {
                using (var db = new DB_UniversityEntities())
                {
                    tbl_m_type_dosen attributs = new tbl_m_type_dosen();
                    attributs.deskripsi = model.deskripsi;
                    attributs.is_active = model.is_active;
                    attributs.created_by = model.created_by;
                    attributs.created_date = model.created_date;
                    attributs.updated_by = model.updated_by;
                    attributs.updated_date = model.updated_date;
                    attributs.kode_type_dosen = model.kode_type_dosen;

                    db.tbl_m_type_dosen.Add(attributs);
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
        public static bool Update(TypeDosenViewModel model)
        {
            bool result = true;
            try
            {
                using (var db = new DB_UniversityEntities())
                {
                    tbl_m_type_dosen attributs = db.tbl_m_type_dosen.Where(o => o.id_type_dosen_pk == model.id_type_dosen_pk).FirstOrDefault();

                    if (attributs != null)
                    {
                        attributs.kode_type_dosen = model.kode_type_dosen;
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
    }
}
