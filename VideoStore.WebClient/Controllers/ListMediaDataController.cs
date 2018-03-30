using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using VideoStore.Services.Interfaces;

namespace VideoStore.WebClient.Controllers
{
    public class ListMediaDataController : Controller
    {
        private ICatalogueService CatalogueService
        {
            get
            {
                return ServiceFactory.Instance.CatalogueService;
            }
        }

        [HttpGet]
        public JsonResult GetAllMedia()
        {
            return Json(CatalogueService.GetMediaItems(0, Int32.MaxValue), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetMedia(int pMediaId)
        {
            return Json(CatalogueService.GetMediaById(pMediaId), JsonRequestBehavior.AllowGet);
        }
    }
}
