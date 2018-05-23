using System;
using Microsoft.AspNetCore.Http;

namespace Backend.net.View
{
    public class PhotoForCreation
    {
        public string url { get; set; }     
        public IFormFile File { get; set; }

        public string Description { get; set; } 
        public DateTime DateAdded { get; set; }
        public string PublicId { get; set; }
        public PhotoForCreation(){
            DateAdded = DateTime.Now;
        }
    }
}