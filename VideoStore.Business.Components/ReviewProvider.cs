using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Business.Components.Interfaces;
using VideoStore.Business.Entities;

namespace VideoStore.Business.Components
{
    public class ReviewProvider : IReviewProvider
    {
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
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                // return lContainer.Review.Include("Stocks").First(p => p.Id == pId);
                return new Review();
            }
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
