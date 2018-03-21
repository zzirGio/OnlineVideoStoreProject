using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Services.MessageTypes
{
    public class Review : MessageType
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }

        public User User { get; set; }
        public Media Media { get; set; }
    }
}
