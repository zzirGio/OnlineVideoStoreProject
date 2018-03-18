using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Services.MessageTypes
{
    public class Media : MessageType
    {
        public String Title { get; set; }
        public String Director { get; set; }
        public String Genre { get; set; }
        public decimal Price { get; set; }
        public int StockCount { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public double AverageRating
        {
            get
            {
                var sum = 0.0d;

                foreach (var review in Reviews)
                {
                    sum += review.Rating;
                }

                return sum/ Math.Max(1, Reviews.Count);
            }
        }
    }
}
