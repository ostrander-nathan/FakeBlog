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
        void AddPostUser(string name, ApplicationUser owner);
        void AddPost(int postId);


        // Read
        Post GetPost(int postId);
        Post GetPost(int postId, string name);


        // Update
        void UpdatePost(int postId, string newname);
        bool UpdatePost(string postId);
        bool AttachUser(string userId, int postId);
  

        // Delete
        bool RemoveUserFromPost(string userId);
        bool RemovePost(int postId);

    }
}
