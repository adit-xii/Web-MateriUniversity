using _02.Materi.University.DataAccess;
using _03.Materi.University.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01.Materi.University.Web.Controllers
{
    public class AgamaController : Controller
    {
        // GET: Agama
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View(AgamaDataAccess.GetListAll());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(AgamaViewModel paramModel)
        {
            try
            {
                paramModel.created_by = "adit";
                paramModel.created_date = DateTime.Now;
                paramModel.updated_by = "adit";
                paramModel.updated_date = DateTime.Now;

                if (AgamaDataAccess.Insert(paramModel))
                {
                    return Json(new { success = true, message = "Data berhasil ditambahkan!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = AgamaDataAccess.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception hasError)
            {
                return Json(new { success = true, message = hasError.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Edit(int paramId)
        {
            return View(AgamaDataAccess.GetDetailsByid(paramId));
        }
        [HttpPost]
        public ActionResult Edit(AgamaViewModel paramModel)
        {
            try
            {
                paramModel.updated_by = "adit";
                paramModel.updated_date = DateTime.Now;

                if (AgamaDataAccess.Update(paramModel))
                {
                    return Json(new { success = true, message = "Data berhasil ditambahkan!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = true, message = AgamaDataAccess.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception hasError)
            {
                return Json(new { success = true, message = hasError.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Details(int paramId)
        {
            return View(AgamaDataAccess.GetDetailsByid(paramId));
        }

    }
}