using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Services.MessageTypes
{
    public class ReviewAuthor : MessageType
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string LocationString => string.Format("{0}, {1}", this.City, this.Country);
    }
}
