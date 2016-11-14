using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DomainModel;
using Microsoft.EntityFrameworkCore;

namespace DatabaseService
{
    public class MySovaDataService : IDataService
    {

        public IList<Post> GetPosts(int page, int pagesize)
        {

            using (var db = new Sova())
            {
                return db.Posts
                    .OrderBy(p => p.id)
                    .Skip(page * pagesize)
                    .Take(pagesize)
                    .ToList();
            }
        }

        public Post GetPost(int id)
        {
            using (var db = new Sova())
            {
                return db.Posts.FirstOrDefault(p => p.id == id);
            }
        }

        public void AddPost(Post post)
        {
            using (var db = new Sova())
            {
                post.id = db.Posts.Max(p => p.id) + 1;
                db.Add(post);
                db.SaveChanges();
            }
        }

        public bool UpdatePost(Post post)
        {
            using (var db = new Sova())

                try
                {
                    db.Attach(post);
                    db.Entry(post).State = EntityState.Modified;
                    return db.SaveChanges() > 0;
                }
                catch (DbUpdateConcurrencyException)
                {
                    return false;
                }

        }

        public bool DeletePost(int id)
        {
            using (var db = new Sova())
            {
                var post = db.Posts.FirstOrDefault(p => p.id == id);
                if (post == null)
                {
                    return false;
                }
                db.Remove(post);
                return db.SaveChanges() > 0;
            }
        }

        public int GetNumberOfPosts()
        {
            using (var db = new Sova())
            {
                return db.Posts.Count();
            }
        }
        public IList<Comment> GetComments(int page, int pagesize)
        {
            using (var db = new Sova())
            {
                return db.Comments
                    .OrderBy(c => c.id)
                    .Skip(page * pagesize)
                    .Take(pagesize)
                    .ToList();
            }
        }

        public Comment GetComment(int id)
        {
            using (var db = new Sova())
            {
                return db.Comments.FirstOrDefault(c => c.id == id);
            }
        }

        public void AddComment(Comment comment)
        {
            using (var db = new Sova())
            {
                comment.id = db.Comments.Max(c => c.id) + 1;
                db.Add(comment);
                db.SaveChanges();
            }
        }

        public bool UpdateComment(Comment comment)
        {
            using (var db = new Sova())

                try
                {
                    db.Attach(comment);
                    db.Entry(comment).State = EntityState.Modified;
                    return db.SaveChanges() > 0;
                }
                catch (DbUpdateConcurrencyException)
                {
                    return false;
                }

        }

        public bool DeleteComment(int id)
        {
            using (var db = new Sova())
            {
                var comment = db.Comments.FirstOrDefault(c => c.id == id);
                if (comment == null)
                {
                    return false;
                }
                db.Remove(comment);
                return db.SaveChanges() > 0;
            }
        }

        public int GetNumberOfComments()
        {
            using (var db = new Sova())
            {
                return db.Comments.Count();
            }
        }

        
    }
}
