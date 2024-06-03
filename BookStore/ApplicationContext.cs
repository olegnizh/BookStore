using System;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;


namespace BookStore
{
	public class ApplicationContext : DbContext
	{
        // Объекты таблицы
        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<BooksOnHand> BooksOnHand { get; set; }

        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string con = "server=localhost;port=3306;database=dbbooks;user=root;password=;";
            optionsBuilder.UseMySql(con, ServerVersion.AutoDetect(con));
        }
    }
}

