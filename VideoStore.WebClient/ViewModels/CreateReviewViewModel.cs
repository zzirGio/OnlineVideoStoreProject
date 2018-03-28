using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoStore.Services.MessageTypes;

namespace VideoStore.WebClient.ViewModels
{
    public class CreateReviewViewModel
    { 
        public string Title { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime ReviewDate { get; set; }
        public User User { get; set; }
        public Media Media { get; set; }

    }
}