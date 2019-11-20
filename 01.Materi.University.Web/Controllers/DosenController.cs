using _02.Materi.University.DataAccess;
using _03.Materi.University.ViewModel;
using _01.Materi.University.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _01.Materi.University.Web.Models.Shared;

namespace _01.Materi.University.Web.Controllers
{
    public class DosenController : Controller
    {
        // GET: Dosen
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List(int? paramPage, int paramPageSize, string paramSearch, int paramAsc, int paramDesc)
        {
            /* for paged */
            int countDataDb = DosenDataAccess.GetCountData(paramSearch);
            PagingModel_Jurusan pg = new PagingModel_Jurusan(countDataDb, paramPage, paramPageSize);
            ViewData["pg"] = pg;

            List<DosenViewModel> listData = DosenDataAccess.GetListAll(paramSearch, paramAsc, paramDesc, ((pg.CurrentPage - 1) * pg.PageSize), pg.PageSize);

            return View("List", listData);

        }
        public ActionResult Create()
        {
            ViewBag.JurusanList = new SelectList(JurusanDataAccess.GetListAll(), "id_jurusan_pk", "nama_jurusan");
            ViewData["TypeDosenList"] = TypeDosenDataAccess.GetListAll();

            return View();
        }
        [HttpPost]
        public ActionResult Create(DosenViewModel paramModel)
        {
            try
            {
                paramModel.created_by = "adit";
                paramModel.created_date = DateTime.Now;
                paramModel.updated_by = "adit";
                paramModel.updated_date = DateTime.Now;
                List<Files> statusUpload = Models.Shared.Helper.FnFileUploadMultiple(Request.Files, Request.Browser.Browser.ToUpper(), "~/Images/");

                if (DosenDataAccess.Insert(paramModel))
                {
                    return Json(new { success = true, message = "Data berhasil ditambahkan!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = DosenDataAccess.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception hasError)
            {
                return Json(new { success = true, message = hasError.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Edit(int paramId)
        {
            ViewBag.JurusanList = new SelectList(JurusanDataAccess.GetListAll(), "id_jurusan_pk", "nama_jurusan");
            ViewData["TypeDosenList"] = TypeDosenDataAccess.GetListAll();
            return View(DosenDataAccess.GetDetailsByid(paramId));
        }
        [HttpPost]
        public ActionResult Edit(DosenViewModel paramModel)
        {
            try
            {
                paramModel.updated_by = "adit";
                paramModel.updated_date = DateTime.Now;

                if (DosenDataAccess.Update(paramModel))
                {
                    return Json(new { success = true, message = "Data berhasil ditambahkan!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = true, message = DosenDataAccess.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception hasError)
            {
                return Json(new { success = true, message = hasError.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Details(int paramId)
        {
            return View(DosenDataAccess.GetDetailsByid(paramId));
        }


        [HttpPost]
        public ActionResult UploadFiles(DosenViewModel paramModel)
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                List<Files> statusUpload = Models.Shared.Helper.FnFileUploadMultiple(Request.Files, Request.Browser.Browser.ToUpper(), "~/Images/");
                return Json(new { success = true, message = "sukses" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = "gagal" }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}