using System;

namespace app.View
{
    public class PhotoForDetail
    {
         public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string Description { get; set; }
        public bool IsMain { get; set; }
        public string Url { get; set; }
    }
}