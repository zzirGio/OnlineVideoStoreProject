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
            var media = ServiceFactory.Instance.CatalogueService.GetMediaById(mediaId);
            var reviews = ServiceFactory.Instance.ReviewService.GetReviewsByMedia(mediaId);

            var reviewAuthors = new List<KeyValuePair<Review, ReviewAuthor>>();

            foreach (var r in reviews)
            {
                var reviewAuthor = ServiceFactory.Instance.ReviewService.GetReviewAuthorByReview(r.UserId);
                reviewAuthors.Add(new KeyValuePair<Review, ReviewAuthor>(r, reviewAuthor));
            }

            var vm = new MediaDetailsViewModel
            {
                Media = media,
                Reviews = reviewAuthors
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
                UserId = user.Id,
                MediaId = media.Id
            };

            ServiceFactory.Instance.ReviewService.CreateReview(newReview);
            return RedirectToAction("Details", new {mediaId = pMediaId});
        }
    }
}