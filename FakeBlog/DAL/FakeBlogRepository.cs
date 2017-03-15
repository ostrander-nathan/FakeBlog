using System;
using System.Collections.Generic;
using FakeBlog.Models;

namespace FakeBlog.DAL
{
    public class FakeBlogRepository : IRepository
    {
        public FakeBlogRepository()
        {
            Context = new FakeBlogContext();
        }

        public FakeBlogRepository(FakeBlogContext context)
        {
            Context = context;
        }

        public FakeBlogContext Context { get; set; }

        public void AddPost(string name, ApplicationUser owner)
        {
            Post post = new Post { Name = name, Owner = owner };
            Context.Posts.Add(post);
            Context.SaveChanges();
        }

        public List<Post> GetPost(int postId)
        {
            throw new NotImplementedException();
        }

        public bool RemovePost(string postId)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePost(string postId)
        {
            throw new NotImplementedException();
        }
    }
}