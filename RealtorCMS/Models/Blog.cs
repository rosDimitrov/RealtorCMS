using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealtorCMS.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [StringLength(int.MaxValue, MinimumLength = 500)]
        public string Content { get; set; }

        [DisplayName("Image name")]
        public string PicturePath { get; set; }

        [DisplayName("Creation Date")]
        public DateTime CreationDate { get; set; }
    }
}