using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Services.MessageTypes;

namespace VideoStore.Services.Interfaces
{
    [ServiceContract]
    public interface IReviewService
    {
        [OperationContract]
        List<Review> GetReviewsByMedia(int mediaId);
        [OperationContract]
        List<Review> GetReviewsByUser(int userId);
        [OperationContract]
        Review GetReviewById(int id);
        [OperationContract]
        ReviewAuthor GetReviewAuthorByReview(int reviewId);
        [OperationContract]
        void CreateReview(Review pReview);
        [OperationContract]
        void UpdateReview(Review pReview);
        [OperationContract]
        void DeleteReview(Review pReview);
    }
}
