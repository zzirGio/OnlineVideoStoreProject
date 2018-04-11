using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Business.Entities;

namespace VideoStore.Business.Components.Interfaces
{
    public interface IReviewProvider
    {
        List<Review> GetReviewsByMedia(int mediaId);
        List<Review> GetReviewsByUser(int userId);
        Review GetReviewById(int id);
        User GetReviewAuthorByReview(int reviewId);
        void CreateReview(Review pReview);
        void UpdateReview(Review pReview);
        void DeleteReview(Review pReview);
    }
}
