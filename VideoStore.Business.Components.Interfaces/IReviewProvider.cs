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
        List<Review> GetReviewsByUsers(int userId);
        Review GetReviewById(int id);
        void CreateReview(User pUser, Media pMedia);
        void UpdateReview(Review pReview);
        void DeleteReview(Review pReview);
    }
}
