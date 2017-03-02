using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FakeBlog.Models
{
    public class Published
    {
        [Key]
        public int PublishedId { get; set; } // publish Id 

        public string Content { get; set; } 

    }
}