using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using VideoStore.Business.Components.Interfaces;
using VideoStore.Business.Entities;

namespace VideoStore.Business.Components
{
    public class ReviewProvider : IReviewProvider
    {
        public List<Review> GetReviewsByMedia(int mediaId)
        {
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                lContainer.Configuration.ProxyCreationEnabled = false;
                return lContainer.Reviews.Where(p => p.Media.Id == mediaId).ToList();
            }
        }

        public List<Review> GetReviewsByUser(int userId)
        {
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                lContainer.Configuration.ProxyCreationEnabled = false;
                return lContainer.Reviews.Where(p => p.User.Id == userId).ToList();
            }
        }

        public Review GetReviewById(int pId)
        {
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                 return lContainer.Reviews.First(p => p.Id == pId);
            }
        }

        public User GetReviewAuthorByReview(int reviewId)
        {
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                return lContainer.Users.First(p => p.Id == reviewId);
            }
        }

        public void CreateReview(Review pReview)
        {
            using (TransactionScope lScope = new TransactionScope())
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                Media media = lContainer.Media.FirstOrDefault(s => s.Id == pReview.MediaId);
                User user = lContainer.Users.FirstOrDefault(s => s.Id == pReview.UserId);
                pReview.Media = media;
                pReview.User = user;
                pReview.Date = DateTime.Now;

                // Update changes to Media.
                media.RatingsCount += 1;
                media.RatingsSum += pReview.Rating;

                lContainer.Reviews.Add(pReview);
                lContainer.SaveChanges();
                lScope.Complete();
            }
        }

        public void UpdateReview(Review pReview)
        {
            using (TransactionScope lScope = new TransactionScope())
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                lContainer.Entry(pReview).State = EntityState.Modified;
                lContainer.SaveChanges();
                lScope.Complete();
            }
        }

        public void DeleteReview(Review pReview)
        {
            using (TransactionScope lScope = new TransactionScope())
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                lContainer.Reviews.Remove(pReview);
                lContainer.SaveChanges();
                lScope.Complete();
            }
        }
    }
}
