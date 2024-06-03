using System;
namespace BookStore.Models
{
	public class BooksOnHand
	{
		public int Id { get; set; }

        /*
        // один к одному
        public int BookId { get; set; } // Внешний ключ
        public List<Book> Books { get; set; }  // Навиг  cв-во

        // один к одному
        public int UserId { get; set; } // Внешний ключ
        public List<User> Users { get; set; }  // Навиг  cв-во
        */


        public int BookId { get; set; } // Внешний ключ
        public Book Book { get; set; }  // Навиг  cв-во

        public int UserId { get; set; } // Внешний ключ
        public User User { get; set; }  // Навиг  cв-во

    }
}

