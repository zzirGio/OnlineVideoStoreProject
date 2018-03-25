using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoStore.Services.MessageTypes;

namespace VideoStore.WebClient.ViewModels
{
    public class MediaDetailsViewModel
    {
        public String Title { get; set; }
        public String Director { get; set; }
        public String Genre { get; set; }
        public decimal Price { get; set; }
        public int StockCount { get; set; }

        public IEnumerable<Review> Reviews { get; set; }

        public double AverageRating
        {
            get
            {
                var sum = 0.0f;
                foreach (var review in this.Reviews)
                {
                    sum += review.Rating;
                }

                return sum / Math.Max(1, this.Reviews.Count());
            }
        }
    }
}