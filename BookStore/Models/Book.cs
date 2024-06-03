using System;
namespace BookStore.Models
{
	public class Book
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }


        public int AuthorId { get; set; }   // Внешний ключ
        public Author Author { get; set; } // Навигационное свойство

        public int GenreId { get; set; }  // Внешний ключ
        public Genre Genre { get; set; } // Навигационное свойство

        public BooksOnHand BooksOnHand { get; set; } // Навигационное свойство
    }
}

