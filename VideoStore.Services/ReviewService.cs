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
            var internalResult = ReviewProvider.GetReviewsByMedia(mediaId);
            var externalResult = MessageTypeConverter.Instance.Convert<
                List<VideoStore.Business.Entities.Review>,
                List<VideoStore.Services.MessageTypes.Review>>(internalResult);

            return externalResult;
        }

        public List<Review> GetReviewsByUser(int userId)
        {
            var internalResult = ReviewProvider.GetReviewsByUser(userId);
            var externalResult = MessageTypeConverter.Instance.Convert<
                List<VideoStore.Business.Entities.Review>,
                List<VideoStore.Services.MessageTypes.Review>>(internalResult);

            return externalResult;
        }

        public Review GetReviewById(int id)
        {
            var internalResult = ReviewProvider.GetReviewById(id);
            var externalResult = MessageTypeConverter.Instance.Convert<
                VideoStore.Business.Entities.Review,
                VideoStore.Services.MessageTypes.Review>(internalResult);

            return externalResult;
        }

        public ReviewAuthor GetReviewAuthorByReview(int reviewId)
        {
            var internalResult = ReviewProvider.GetReviewAuthorByReview(reviewId);
            var externalResult = MessageTypeConverter.Instance.Convert<
                VideoStore.Business.Entities.User,
                VideoStore.Services.MessageTypes.ReviewAuthor>(internalResult);

            return externalResult;
        }

        public void CreateReview(Review pReview)
        {
            var internalType = MessageTypeConverter.Instance.Convert<
                VideoStore.Services.MessageTypes.Review,
                VideoStore.Business.Entities.Review>(
                pReview);
            ReviewProvider.CreateReview(internalType);
        }

        public void UpdateReview(Review pReview)
        {
            var internalType = MessageTypeConverter.Instance.Convert<
                VideoStore.Services.MessageTypes.Review,
                VideoStore.Business.Entities.Review>(
                pReview);
            ReviewProvider.UpdateReview(internalType);
        }

        public void DeleteReview(Review pReview)
        {
            var internalType = MessageTypeConverter.Instance.Convert<
                VideoStore.Services.MessageTypes.Review,
                VideoStore.Business.Entities.Review>(
                pReview);
            ReviewProvider.DeleteReview(internalType);
        }
    }
}
