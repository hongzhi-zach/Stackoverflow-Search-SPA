using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;
using Microsoft.EntityFrameworkCore;

namespace DatabaseService
{
    public class Sova : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().ToTable("post");
            modelBuilder.Entity<Post>().Property(p => p.id).HasColumnName("postid");
            modelBuilder.Entity<Post>().Property(p => p.typeid).HasColumnName("posttypeid");
            modelBuilder.Entity<Post>().Property(p => p.parentid).HasColumnName("parentid");
            modelBuilder.Entity<Post>().Property(p => p.acceptedanswerid).HasColumnName("acceptedanswerid");
            modelBuilder.Entity<Post>().Property(p => p.creationdate).HasColumnName("creationdate");
            modelBuilder.Entity<Post>().Property(p => p.score).HasColumnName("score");
            modelBuilder.Entity<Post>().Property(p => p.body).HasColumnName("body");
            modelBuilder.Entity<Post>().Property(p => p.closeddate).HasColumnName("closeddate");
            modelBuilder.Entity<Post>().Property(p => p.title).HasColumnName("title");
            modelBuilder.Entity<Post>().Property(p => p.userid).HasColumnName("userid");
            modelBuilder.Entity<Comment>().ToTable("comment");
            modelBuilder.Entity<Comment>().Property(t => t.id).HasColumnName("commentid");
            modelBuilder.Entity<Comment>().Property(t => t.postid).HasColumnName("postid");
            modelBuilder.Entity<Comment>().Property(t => t.score).HasColumnName("commentscore");
            modelBuilder.Entity<Comment>().Property(t => t.text).HasColumnName("commenttext");
            modelBuilder.Entity<Comment>().Property(t => t.createdate).HasColumnName("commentcreatedate");
            modelBuilder.Entity<Comment>().Property(t => t.userid).HasColumnName("userid");
           
            base.OnModelCreating(modelBuilder);
        }
       


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=hzhang;uid=root;pwd=test");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
