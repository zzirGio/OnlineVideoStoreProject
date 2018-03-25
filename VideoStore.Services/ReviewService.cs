using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Business.Components.Interfaces;
using VideoStore.Services.Interfaces;
using VideoStore.Services.MessageTypes;

namespace VideoStore.Services
{
    public class ReviewService : IReviewService
    {
        private IReviewProvider ReviewProvider
        {
            get { return ServiceFactory.GetService<IReviewProvider>(); }
        }

        public List<Review> GetReviewsByMedia(int mediaId)
        {
            var list = new List<Review>();
            return list;
        }

        public List<Review> GetReviewsByUsers(int userId)
        {
            var list = new List<Review>();
            return list;
        }

        public Review GetReviewById(int id)
        {
            return new Review();
        }

        public void CreateReview(User pUsers, Media pMedia, Review pReview)
        {

        }

        public void UpdateReview(Review pReview)
        {

        }

        public void DeleteReview(Review pReview)
        {

        }

    }
}
