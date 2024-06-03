using System;
using BookStore.Models;

namespace BookStore.Repositories
{
	public class UserRepository : IUserRepository
	{
        private ApplicationContext db { get; set; } = new ApplicationContext();

        public void Add(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void Delete(User model)
        {
            db.Users.Remove(model);
            db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var user = db.Users.Where(u => u.Id == id).FirstOrDefault();
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        public User FindById(int id)
        {
            var ret = db.Users.Where(u => u.Id == id).FirstOrDefault();
            return ret;
        }

        public List<User> FindByName(string name)
        {
            var ret = db.Users.Where(u => u.Name.Contains(name)).ToList();
            return ret;
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();            
        }

        public void Update(User user)
        {
            db.Users.Update(user);
            db.SaveChanges();
        }

        public void UpdateNameById(int id, string name)
        {
            User user = FindById(id);
            user.Name = name;
            db.SaveChanges();
        }
    }
}

