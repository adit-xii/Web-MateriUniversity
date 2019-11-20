using _02.Materi.University.DataAccess;
using _03.Materi.University.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01.Materi.University.Web.Controllers
{
    public class TypeDosenController : Controller
    {
        // GET: TypeDosen
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View(TypeDosenDataAccess.GetListAll());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TypeDosenViewModel paramModel)
        {
            try
            {
                paramModel.created_by = "adit";
                paramModel.created_date = DateTime.Now;
                paramModel.updated_by = "adit";
                paramModel.updated_date = DateTime.Now;

                if (TypeDosenDataAccess.Insert(paramModel))
                {
                    return Json(new { success = true, message = "Data berhasil ditambahkan!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = TypeDosenDataAccess.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception hasError)
            {
                return Json(new { success = true, message = hasError.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Edit(int paramId)
        {
            return View(TypeDosenDataAccess.GetDetailsByid(paramId));
        }
        [HttpPost]
        public ActionResult Edit(TypeDosenViewModel paramModel)
        {
            try
            {
                paramModel.updated_by = "adit";
                paramModel.updated_date = DateTime.Now;

                if (TypeDosenDataAccess.Update(paramModel))
                {
                    return Json(new { success = true, message = "Data berhasil ditambahkan!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = true, message = TypeDosenDataAccess.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception hasError)
            {
                return Json(new { success = true, message = hasError.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Details(int paramId)
        {
            return View(TypeDosenDataAccess.GetDetailsByid(paramId));
        }

    }
}