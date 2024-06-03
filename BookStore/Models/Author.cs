using System;
namespace BookStore.Models
{
	public class Author
	{
		public int Id { get; set; }
		public string Name { get; set; }

        // Навигационное свойство
        public List<Book> Books { get; set; }
    }
}

