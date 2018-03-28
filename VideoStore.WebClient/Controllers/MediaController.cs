using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using VideoStore.Services.Interfaces;
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
            var reviews = ServiceFactory.Instance.ReviewService.GetReviewsByMedia(media.Id);
            var vm = new MediaDetailsViewModel
            {
                Media = media,
                Reviews = reviews
            };

            return View(vm);
        }

        [HttpGet]
        public ActionResult CreateReview(int pMediaId)
        {
            var media = ServiceFactory.Instance.CatalogueService.GetMediaById(pMediaId);
            var user = ServiceFactory.Instance.UserService.GetUserByUserName(User.Identity.GetUserName());
            var vm = new CreateReviewViewModel
            {
                ReviewDate = DateTime.Now,
                Media = media,
                User = user
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult CreateReview(CreateReviewViewModel vm, int pMediaId, string pUserName)
        {
            var media = ServiceFactory.Instance.CatalogueService.GetMediaById(pMediaId);
            var user = ServiceFactory.Instance.UserService.GetUserByUserName(pUserName);
            var newReview = new Review
            {
                Title = vm.Title,
                Content = vm.Content,
                Rating = vm.Rating,
                Date = vm.ReviewDate,
                User = user,
                Media = media
            };

            ServiceFactory.Instance.ReviewService.CreateReview(newReview);
            return RedirectToAction("Details", new {mediaId = vm.Media.Id});
        }
    }
}