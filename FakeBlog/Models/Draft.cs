using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FakeBlog.Models
{
    public class Draft
    {
        [Key]
        public int DraftId { get; set; }

        public List<Published> ArePublished { get; set; }

    }
}