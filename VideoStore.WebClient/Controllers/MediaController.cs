using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Services.MessageTypes;
using VideoStore.WebClient.ViewModels;
using VideoStore.WebClient.ViewModels;


namespace VideoStore.WebClient.Controllers
{
    public class MediaController : Controller
    {
        // GET: Media
        public ActionResult Index()
        {
            return View("Details");
        }

        public ActionResult Details(int mediaId)
        {
            // get Media item
            var media = ServiceFactory.Instance.CatalogueService.GetMediaById(mediaId);

            return View(new MediaDetailsViewModel { Media = media});
        }

        [HttpPost]
        public ActionResult SaveReview()
        {
            var media = new Media();
            return RedirectToAction("Details", new {mediaId = media.Id});
        }
    }
}