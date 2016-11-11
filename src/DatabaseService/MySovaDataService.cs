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
        
        public IList<Comments> GetComments(int page, int pagesize)
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

        public Comments GetComments(int id)
        {
            using (var db = new Sova())
            {
                return db.Comments.FirstOrDefault(c => c.id == id);
            }
        }

        public void AddComments(Comments comment)
        {
            using (var db = new Sova())
            {
                comment.id = db.Comments.Max(c => c.id) + 1;
                db.Add(comment);
                db.SaveChanges();
            }
        }

        public bool UpdateComments(Comments comment)
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

        public bool DeleteComments(int id)
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
