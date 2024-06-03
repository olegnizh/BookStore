using BookStore.Models;
using BookStore.Repositories;
using BookStore.Views.Messages;

namespace BookStore.Views
{
	public static class MainMenuView
	{
		public static void Show()
		{
			Console.WriteLine("Основное меню:");
            Console.WriteLine(" 1 - Работа с книгами");
            Console.WriteLine(" 2 - Работа с пользователями");
            Console.WriteLine(" 3 - Заполнить базу тестовыми данными");
            Console.WriteLine("");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    BookMenuView.Show();
                    break;

                case "2":
                    Console.Clear();
                    UserMenuView.Show();
                    break;

                case "3":                    
                    WrightDemoData();
                    break;

                default:
                    AllertMessage.Show("");
                    break;                    
            }
            Console.WriteLine("");
        }

        private static void WrightDemoData()
        {
            // Заполняем авторов
            List<Author> authors = new()
            {
                new Author { Name = "Анжей Сапковский" },
                new Author { Name = "Александр Пушкин" },
                new Author { Name = "Издательство \"Наука\"" },
                new Author { Name = "Дарья Донцова" },
                new Author { Name = "Братья Стругацкие" },
                new Author { Name = "Космомэн Петров" }
            };

            AuthorRepository authorRepository = new();
            foreach (var a in authors)
                authorRepository.Add(a);

            // Заполняем жанры
            List<Genre> genres = new()
            {
                new Genre { Name = "Роман"},
                new Genre { Name = "Фэнтези"},
                new Genre { Name = "Учебник"},
                new Genre { Name = "Стихи"},
                new Genre { Name = "Фантастика"},
                new Genre { Name = "Поэма"}
            };
            GenreRepository genreRepository = new();
            foreach (var g in genres)
                genreRepository.Add(g);

            // Заполняем книги
            List<Book> books = new()
            {
                new Book{ Name = "Ведьмак: Последнее желание", PublishDate = new DateTime(1986, 1, 1, 0, 0, 0), AuthorId = 1, GenreId = 2 },
                new Book{ Name = "Трудно быть богом", PublishDate = new DateTime(1964, 1, 1, 0, 0, 0), AuthorId = 5, GenreId = 5 },
                new Book{ Name = "Биология", PublishDate = new DateTime(2007, 1, 1, 0, 0, 0), AuthorId = 3, GenreId = 3 },
                new Book{ Name = "Капитанская дочка", PublishDate = new DateTime(1836, 1, 1, 0, 0, 0), AuthorId = 2, GenreId = 1 },
                new Book{ Name = "Евгений Онегин", PublishDate = new DateTime(1833, 1, 1, 0, 0, 0), AuthorId = 2, GenreId = 4 },
                new Book{ Name = "Пистолет и тайна", PublishDate = new DateTime(2014, 1, 1, 0, 0, 0), AuthorId = 4, GenreId = 1 },
                new Book{ Name = "Космос", PublishDate = new DateTime(2006, 1, 1, 0, 0, 0), AuthorId = 6, GenreId = 3 },
                new Book{ Name = "Космос Новое издание", PublishDate = new DateTime(2023, 1, 1, 0, 0, 0), AuthorId = 6, GenreId = 3 },
                new Book{ Name = "Ведьмак: Меч Предназначения ", PublishDate = new DateTime(1992, 1, 1, 0, 0, 0), AuthorId = 1, GenreId = 2 },
            };
            BookRepository bookRepository = new();
            foreach (var b in books)
                bookRepository.Add(b);

            // Заполняем пользователей
            List<User> users = new()
            {
                new User{ Name = "Пользователь 1" },
                new User{ Name = "Пользователь 2" },
                new User{ Name = "Пользователь 3" },
                new User{ Name = "Пользователь 4" },
                new User{ Name = "Пользователь 5" }
            };
            UserRepository userRepository = new();
            foreach (var u in users)
                userRepository.Add(u);

            // Заполняем книги на руках пользователей
            List<BooksOnHand> booksOnHands = new()
            {
                new BooksOnHand { BookId = 5, UserId = 3 },
                new BooksOnHand { BookId = 2, UserId = 2 },
                new BooksOnHand { BookId = 1, UserId = 2 },
                new BooksOnHand { BookId = 9, UserId = 5 },
            };
            BooksOnHandRepository booksOnHandRepository = new();
            foreach (var boh in booksOnHands)
                booksOnHandRepository.Add(boh);

            SuccessMessage.Show("База заполнена тестовыми данными!");
        }

    }
}

