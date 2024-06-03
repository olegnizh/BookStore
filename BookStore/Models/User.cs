using System;
namespace BookStore.Models
{
	public class User
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }

        // Навигационное свойство
        public List<BooksOnHand> BooksOnHands { get; set; }
    }
}

