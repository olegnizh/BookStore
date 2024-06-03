using System;
using BookStore.Models;

namespace BookStore.Repositories
{
	public class GenreRepository : IBaseRepository<Genre>
	{
        private ApplicationContext db { get; set; } = new ApplicationContext();

        public void Add(Genre genre)
        {
            db.Genres.Add(genre);
            db.SaveChanges();
        }

        public List<Genre> GetAll()
        {
            return db.Genres.ToList();
        }

        public void Update(Genre genre)
        {
            db.Genres.Update(genre);
            db.SaveChanges();
        }

        public void Delete(Genre genre)
        {
            db.Genres.Remove(genre);
            db.SaveChanges();
        }        

        public Genre FindById(int id)
        {
            var ret = db.Genres.Where(a => a.Id == id).FirstOrDefault();
            return ret;
        }

        public List<Genre> FindByName(string name)
        {
            var ret = db.Genres.Where(a => a.Name.Contains(name)).ToList();
            return ret;
        }
    }
}

