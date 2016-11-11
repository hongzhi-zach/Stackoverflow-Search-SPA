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
        //this is a change
        public DbSet<Comments> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comments>().ToTable("comments");
            modelBuilder.Entity<Comments>().Property(t => t.id).HasColumnName("commentid");
            modelBuilder.Entity<Comments>().Property(t => t.postid).HasColumnName("postid");
            modelBuilder.Entity<Comments>().Property(t => t.score).HasColumnName("commentscore");
            modelBuilder.Entity<Comments>().Property(t => t.text).HasColumnName("commenttext");
            modelBuilder.Entity<Comments>().Property(t => t.createdate).HasColumnName("commentcreatedate");
            modelBuilder.Entity<Comments>().Property(t => t.userid).HasColumnName("userid");

            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=sova;uid=root;pwd=1dunnoathing");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
