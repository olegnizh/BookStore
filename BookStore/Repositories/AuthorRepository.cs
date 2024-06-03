using System;
using BookStore.Models;

namespace BookStore.Repositories
{
	public class AuthorRepository : IBaseRepository<Author>
	{
        private ApplicationContext db { get; set; } = new ApplicationContext();

        public void Add(Author author)
        {
            db.Authors.Add(author);
            db.SaveChanges();
        }

        public List<Author> GetAll()
        {
            return db.Authors.ToList();
        }

        public void Update(Author author)
        {
            db.Authors.Update(author);
            db.SaveChanges();
        }

        public void Delete(Author author)
        {
            db.Authors.Remove(author);
            db.SaveChanges();
        }

        public Author FindById(int id)
        {
            var author = db.Authors.Where(a => a.Id == id).FirstOrDefault();
            return author;
        }

        public List<Author> FindByName(string name)
        {
            var authors = db.Authors.Where(a => a.Name.Contains(name)).ToList();
            return authors;
        }
    }
}

