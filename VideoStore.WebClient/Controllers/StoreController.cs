using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.WebClient.ViewModels;

namespace VideoStore.WebClient.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListMedia()
        {
            return View(new CatalogueViewModel());
        }

        public ActionResult ListMediaWebAPI()
        {
            return View("ListMediaWebApi");
        }

        [HttpGet]
        public JsonResult GetAllMedia()
        {
            return Json(ServiceFactory.Instance.CatalogueService.GetMediaItems(0, Int32.MaxValue),
                JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetMedia(int pMediaId)
        {
            return Json(ServiceFactory.Instance.CatalogueService.GetMediaById(pMediaId),
                JsonRequestBehavior.AllowGet);
        }
    }
}