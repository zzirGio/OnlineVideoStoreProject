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
        private IReviewService reviewService
        {
            get { return ServiceFactory.Instance.ReviewService; }
        }

        // GET: Media
        public ActionResult Index()
        {
            return View("Details");
        }

        public ActionResult Details(int mediaId)
        {
            // get Media item
            var media = ServiceFactory.Instance.CatalogueService.GetMediaById(mediaId);
            var vm = new MediaDetailsViewModel
            {
                Media = media
            };

            return View(vm);
        }

        [HttpGet]
        public ActionResult CreateReview(Media pMedia, string username)
        {
            var user = ServiceFactory.Instance.UserService.GetUserByUserName(User.Identity.GetUserName());
            var vm = new CreateReviewViewModel
            {
                ReviewDate = DateTime.Now,
                ReviewerName = user.Name,
                Media = pMedia,
                User = user
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult CreateReview(CreateReviewViewModel vm)
        {
            Review newReview = new Review
            {
                Title = vm.Title,
                Content = vm.Content,
                Rating = vm.Rating,
                Date = vm.ReviewDate,
                User = vm.User,
                Media = vm.Media
            };

            reviewService.CreateReview(newReview);
            return RedirectToAction("Details", new {mediaId = vm.Media.Id});
        }
    }
}