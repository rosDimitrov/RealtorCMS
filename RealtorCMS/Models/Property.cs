using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace RealtorCMS.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public PropertyType PropertyType { get; set; }
        public int SquareFeet { get; set; }
        public int NumberOfBaths { get; set; }
        public int NumberOfBeds { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public string MapLink { get; set; }
        public string YouTubeLink { get; set; }

        [DisplayName("Featured")]
        public bool IsFeatured { get; set; }
        public DateTime CreateDate { get; set; }
    }
}