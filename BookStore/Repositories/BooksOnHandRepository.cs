using System;
using BookStore.Models;

namespace BookStore.Repositories
{
    public class BooksOnHandRepository : IBaseRepository<BooksOnHand>
    {
        private ApplicationContext db { get; set; } = new ApplicationContext();

        // Задание 25.5.4 5.Получать булевый флаг о том, есть ли определенная книга на руках у пользователя.
        public bool FindByBookAndUser(Book book, User user)
        {
            var ret = db.BooksOnHand.Where(b => b.BookId == book.Id).All(u => u.UserId == user.Id);
            return ret;
        }

        // Задание 25.5.4 6.Получать количество книг на руках у пользователя
        public int BookOnHandsCount(User user)
        {
            var ret = db.BooksOnHand.Where(u => u.UserId == user.Id).ToList().Count();
            return ret;
        }

        public void Add(BooksOnHand model)
        {
            db.BooksOnHand.Add(model);
            db.SaveChanges();
        }

        public void Delete(BooksOnHand model)
        {
            // В разработке
            throw new NotImplementedException();
        }

        public BooksOnHand FindById(int id)
        {
            // В разработке
            throw new NotImplementedException();
        }

        public List<BooksOnHand> FindByName(string name)
        {
            // В разработке
            throw new NotImplementedException();
        }

        public List<BooksOnHand> GetAll()
        {
            // В разработке
            throw new NotImplementedException();
        }

        public void Update(BooksOnHand model)
        {
            // В разработке
            throw new NotImplementedException();
        }
    }
}

