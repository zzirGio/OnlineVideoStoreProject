using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoStore.Services.MessageTypes;

namespace VideoStore.WebClient.ViewModels
{
    public class MediaDetailsViewModel
    {
        public Media Media { get; set; }

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