using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VideoStore.Services.MessageTypes;

namespace VideoStore.WebClient.ViewModels
{
    public class MediaDetailsViewModel
    {
        public Media Media { get; set; }
        public IEnumerable<KeyValuePair<Review, ReviewAuthor>> Reviews { get; set; }
    }
}