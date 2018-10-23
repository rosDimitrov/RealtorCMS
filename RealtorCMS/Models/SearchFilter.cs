using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealtorCMS.Models
{
    public class SearchFilter
    {
        public int Baths { get; set; }
        public int Beds { get; set; }
        public int PriceMin { get; set; }
        public int PriceMax { get; set; }
        public int SqftMin { get; set; }
        public int SqftMax { get; set; }
        public string City { get; set; }

    }
}