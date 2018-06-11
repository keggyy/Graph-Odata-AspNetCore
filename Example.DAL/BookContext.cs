using Example.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Example.DAL
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public BookContext() : base()
        {
        }

        public BookContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publisher>()
                .HasMany(p => p.Books)
                .WithOne(b => b.Publisher)
                .HasForeignKey(b => b.PublisherId);

            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //IConfigurationRoot configuration = new ConfigurationBuilder()
                //.SetBasePath(Directory.GetCurrentDirectory())
                //.AddJsonFile("appsettings.json")
                //.Build();
                var connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=BookDB;Integrated Security=True;MultipleActiveResultSets=True";//configuration.GetConnectionString("DbCoreConnectionString");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
