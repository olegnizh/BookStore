using System;
namespace BookStore.Models
{
	public class Genre
	{
        public int Id { get; set; }
        public string Name { get; set; }

        // Навигационное свойство
        public List<Book> Books { get; set; }
    }
}

