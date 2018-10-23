using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace RealtorCMS.Models
{
    public class PropertyViewModel
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        [DisplayName("Property Type")]
        public PropertyType PropertyType { get; set; }

        [DisplayName("Square Feet")]
        public int SquareFeet { get; set; }

        [DisplayName("Number of Baths")]
        public int NumberOfBaths { get; set; }

        [DisplayName("Number of Beds")]
        public int NumberOfBeds { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public HttpPostedFileBase File { get; set; }

        [DisplayName("Map link")]
        public string MapLink { get; set; }

        [DisplayName("Video Link")]
        public string YouTubeLink { get; set; }

        [DisplayName("Featured")]
        public bool IsFeatured { get; set; }
    }
}