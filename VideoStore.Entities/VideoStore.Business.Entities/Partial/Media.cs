using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoStore.Business.Entities
{
    public partial class Media
    {
        public decimal AverageRating => this.RatingsSum / Math.Max(1, this.RatingsCount);
    }
}
