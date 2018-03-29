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

        public List<Review> GetReviewsByUsers(int userId)
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

        public void CreateReview(Review pReview)
        {
            using (TransactionScope lScope = new TransactionScope())
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                Media media = lContainer.Media.FirstOrDefault(s => s.Id == pReview.Media.Id);
                User user = lContainer.Users.FirstOrDefault(s => s.Id == pReview.User.Id);
                pReview.Media = media;
                pReview.User = user;
                pReview.Date = DateTime.Now;

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
