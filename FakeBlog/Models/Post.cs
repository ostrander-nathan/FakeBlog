﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FakeBlog.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        public string  Name { get; set; }

        public List<Draft> Drafts { get; set; }

        public ApplicationUser Owner { get; set; }
}
}