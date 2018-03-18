using System;

namespace VideoStore.Services.MessageTypes
{
    public class Review : MessageType
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public Media Media { get; set; }
        public User User { get; set; }

        public string Location => string.Format("{0}, {1}", User.City, User.Country);
    }
}
