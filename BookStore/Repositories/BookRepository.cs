using System;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories
{
	public class BookRepository : IBookRepository
	{
        private ApplicationContext db { get; set; } = new ApplicationContext();

        // Задание 25.5.4 1.Получать список книг определенного жанра и вышедших между определенными годами
        public List<Book> FindByGenreAndDate(Genre genre, DateTime startDate, DateTime endDate)
        {
            var ret = db.Books.Where(b => b.GenreId == genre.Id).Where(p => p.PublishDate >= startDate && p.PublishDate <= endDate).ToList();
            return ret;
        }

        // Задание 25.5.4 2.Получать количество книг определенного автора в библиотеке.
        public List<Book> FindByAuthor(Author author)
        {
            var ret = db.Books.Where(b => b.AuthorId == author.Id).ToList();
            return ret;
        }

        // Задание 25.5.4 3.Получать количество книг определенного жанра в библиотеке.
        public List<Book> FindByGenre(Genre genre)
        {
            var ret = db.Books.Where(b => b.GenreId == genre.Id).ToList();
            return ret;
        }

        // Задание 25.5.4 4.Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.
        public bool FindByNameAndAuthor(string bookName, Author author)
        {
            var ret = db.Books.Where(b => b.Name == bookName).All(b => b.AuthorId == author.Id);
            return ret;
        }

        // Задания 25.5.4 5 и 6 в репозитории "BooksOnHandRepository"

        // Задание 25.5.4 7.Получение последней вышедшей книги.
        public Book FindByLastPublishDate()
        {
            var ret = db.Books.OrderByDescending(b => b.PublishDate).FirstOrDefault();
            return ret;
        }

        // Задание 25.5.4 8.Получение списка всех книг, отсортированного в алфавитном порядке по названию.
        public List<Book> GetAllSortABC()
        {
            var ret = db.Books.OrderBy(b => b.Name).ToList();
            return ret;
        }

        // Задание 25.5.4 9.Получение списка всех книг, отсортированного в порядке убывания года их выхода.
        public List<Book> GetAllSortPublishDate()
        {
            var ret = db.Books.OrderByDescending(b => b.PublishDate).ToList();
            return ret;
        }

        public void Add(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            Delete(FindById(id));
        }

        public void Delete(Book book)
        {
            db.Books.Remove(book);
            db.SaveChanges();
        }

        public List<Book> GetAll()
        {
            return db.Books.ToList();
        }

        public Book FindById(int id)
        {
            var book = db.Books.Where(b => b.Id == id).FirstOrDefault();
            return book;
        }

        public List<Book> FindByName(string name)
        {
            var books = db.Books.Include(a => a.Author).Include(g => g.Genre).Where(b => b.Name.Contains(name)).ToList();
            return books;
        }

        public void Update(Book book)
        {
            db.Update(book);
            db.SaveChanges();
        }

        public void UpdatePublishDateById(int id, DateTime newDate)
        {
            Book book = FindById(id);
            book.PublishDate = newDate;
            Update(book);
        }
    }
}

