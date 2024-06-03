using BookStore.Models;

namespace BookStore.Repositories
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        public List<Book> FindByGenreAndDate(Genre genre, DateTime startDate, DateTime endDate);
        public void UpdatePublishDateById(int id, DateTime newDate);
        public void DeleteById(int id);
    }
}