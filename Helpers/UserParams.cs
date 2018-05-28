namespace app.Helpers
{
    public class UserParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; }

        public int pageSize;
        public int PageSize
         { 
             get{return pageSize;}
             set{pageSize = (value > MaxPageSize) ? MaxPageSize : value;} 
         }
         public int UserId { get; set; }
         public string Gjinia { get; set; }

    }
}