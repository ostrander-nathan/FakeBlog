using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FakeBlog.Models
{
    public class BlogUser
    {
        [Key]
        public int BlogUserID { get; set; } // Primary Key

        [MinLength(10)]
        [MaxLength(60)]
        public string Email { get; set; }

        [MaxLength(60)]
        public string Username { get; set; }

        [MaxLength(60)]
        public string Fullname { get; set; }

        public ApplicationUser BaseUser { get; set; } // 1 to 1 relationship

        public List<Post> Posts { get; set; } // 1 to many (Posts) relationship


    }
}