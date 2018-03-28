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

        public double AverageRating
        {
            get
            {
                var sum = 0.0f;
                foreach (var review in this.Media.Reviews)
                {
                    sum += review.Rating;
                }

                return sum / Math.Max(1, this.Media.Reviews.Count());
            }
        }
    }
}