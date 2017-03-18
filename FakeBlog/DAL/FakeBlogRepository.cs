using System;
using System.Collections.Generic;
using FakeBlog.Models;
using System.Linq;

namespace FakeBlog.DAL
{
    public class FakeBlogRepository : IRepository
    {
        public FakeBlogContext Context { get; set; }

        public FakeBlogRepository()
        {
            Context = new FakeBlogContext();
        }

        public FakeBlogRepository(FakeBlogContext context)
        {
            Context = context;
        }

        public void AddPost(int postId)
        {

            throw new NotImplementedException();
        }

        public void AddPost(string name, ApplicationUser owner)
        {
            Post post = new Post { Name = name, Owner = owner };
            Context.Posts.Add(post);
            Context.SaveChanges();
        }

        public void AddPostUser(string name, ApplicationUser owner)
        {
            throw new NotImplementedException();
        }

        public bool AttachUser(string userId, int postId)
        {
            throw new NotImplementedException();
        }

        public Post GetPost(int postId, string name)
        {
            throw new NotImplementedException();
        }

        public Post GetPost(int postId)
        {
            Post found_post = Context.Posts.FirstOrDefault(b => b.PostId == postId); // returns null if nothing is found
            return found_post;
            throw new NotImplementedException();
        }

        public bool RemovePost(int postId)
        {
            Post found_post = GetPost(postId);
            if (found_post != null)
            {
                Context.Posts.Remove(found_post);
                Context.SaveChanges();
                return true;
            }
            return false;
        }


        public bool RemoveUserFromPost(string userId)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePost(string postId)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePost(int postId, string content)
        {
            Context.Posts.Add
        }
    }
}