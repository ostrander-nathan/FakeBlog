using FakeBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeBlog.DAL
{
    public interface IRepository
    {
        // List of methods to help deliver features
        // Create
        void AddPost(string name, ApplicationUser owner);
       

        // Read
        List<Post> GetPost(int postId);
 

        // Update
        bool UpdatePost(string postId);
  

        // Delete
        bool RemovePost(string postId);

    }
}
