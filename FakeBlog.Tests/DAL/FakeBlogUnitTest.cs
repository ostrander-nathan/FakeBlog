using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeBlog.Models;
using FakeBlog.DAL;
using System.Linq;
using Moq;
using System.Data.Entity;
using System.Collections.Generic;

namespace FakeBlog.Tests.DAL
{
        [TestClass]
        public class FakeBlogUnitTest
        {
        public FakeBlogRepository repo { get; set; }
        public ApplicationUser sally { get; set; }
        public IQueryable<Post> query_posts { get; set; }
        public Mock<FakeBlogContext> fake_context { get; set; }
        public Mock<DbSet<Post>> mock_post_set { get;  set; }
        public List<Post> fake_post_table { get;set; }

        [TestInitialize]
        public void Setup()
        {
            fake_post_table = new List<Post>();
            fake_context = new Mock<FakeBlogContext>();
            mock_post_set = new Mock<DbSet<Post>>();
            repo = new FakeBlogRepository(fake_context.Object);
            sally = new ApplicationUser { Id = "sally-id-1" };
        }

        public void CreateFakeDatabase()
        {
            query_posts = fake_post_table.AsQueryable(); // Re-express this list as something that understands queries
            // Hey LINQ, use the Provider from our *cough* fake *cough* board table/list
            mock_post_set.As<IQueryable<Post>>().Setup(b => b.Provider).Returns(query_posts.Provider);
            mock_post_set.As<IQueryable<Post>>().Setup(b => b.Expression).Returns(query_posts.Expression);
            mock_post_set.As<IQueryable<Post>>().Setup(b => b.ElementType).Returns(query_posts.ElementType);
            mock_post_set.As<IQueryable<Post>>().Setup(b => b.GetEnumerator()).Returns(() => query_posts.GetEnumerator());
                 
            mock_post_set.Setup(b => b.Add(It.IsAny<Post>())).Callback((Post post) => fake_post_table.Add(post));
            mock_post_set.Setup(b => b.Remove(It.IsAny<Post>())).Callback((Post post) => fake_post_table.Remove(post));
           // mock_post_set.Setup(b => b.) Not sure what to impliment to mock a update
           
            fake_context.Setup(c => c.Posts).Returns(mock_post_set.Object); // Context.Boards returns fake_board_table (a list)
        }

        [TestMethod]
        public void EnsureICanAddAPost()
        {
            // Arrange
            CreateFakeDatabase();

            ApplicationUser a_user = new ApplicationUser
            {
                Id = "my-user-id",
                UserName = "Sammy",
                Email = "sammy@gmail.com"
            };

            // Act
            repo.AddPost("My Post", a_user);

            // Assert
            Assert.AreEqual(1, repo.Context.Posts.Count());
        }

        [TestMethod]
        public void EnsureICanRemovePost()
        {
            //Arrange
            fake_post_table.Add(new Post { PostId = 1, Name = "My Post", Owner = sally });
            fake_post_table.Add(new Post { PostId = 2, Name = "My Post", Owner = sally });
            fake_post_table.Add(new Post { PostId = 3, Name = "My Post", Owner = sally });

            CreateFakeDatabase();

            // Act
            int expected_board_count = 2;
            repo.RemovePost(3);
            int actual_board_count = repo.Context.Posts.Count();
            //Assert
            Assert.AreEqual(expected_board_count, actual_board_count);


        }
        [TestMethod]
        public void EnsureICanUpdatePost()
        {
            // Arrange

            //Act

            //Assert
        

        }
    }
}
