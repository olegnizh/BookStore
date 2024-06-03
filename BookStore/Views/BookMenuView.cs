using System;
using BookStore.Models;
using BookStore.Repositories;
using BookStore.Views.Messages;

namespace BookStore.Views
{
	public static class BookMenuView
	{
		public static void Show()
		{
            bool menuWhile = true;
            while (menuWhile)
            {
                Console.WriteLine("Меню работы с книгами:");
                Console.WriteLine(" 1 - Новая книга");
                Console.WriteLine(" 2 - Список всех книг");
                Console.WriteLine(" 3 - Поиск книг");
                Console.WriteLine(" 4 - Книги на руках (в разработке)");
                Console.WriteLine(" 5 - Авторы");
                Console.WriteLine(" 6 - Жанры");
                Console.WriteLine(" 7 - Поиск по жанру и между датами (Задание 25.5.4)");
                Console.WriteLine(" 8 - Поиск по автору (Задание 25.5.4)");
                Console.WriteLine(" 9 - Поиск по жанру (Задание 25.5.4)");
                Console.WriteLine(" 10 - Поиск по названию и автору (Задание 25.5.4)");
                Console.WriteLine(" 11 - Проверить книгу на руках пользователя (Задание 25.5.4)");
                Console.WriteLine(" 12 - Получить количество книг на руках у выбранного пользователя (Задание 25.5.4)");
                Console.WriteLine(" 13 - Получение последней вышедшей книги (Задание 25.5.4)");
                Console.WriteLine(" 14 - Получение всех книг в алфавитномм порядке (Задание 25.5.4)");
                Console.WriteLine(" 15 - Получение всех книг, в порядке убывания года (Задание 25.5.4)");

                Console.WriteLine(" 0 - Назад");
                Console.WriteLine("");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddBook();
                        break;

                    case "2":
                        BookList();
                        break;

                    case "3":
                        BookFind();
                        break;

                    case "4":
                        BooksOnHandInf();
                        break;

                    case "5":
                        Console.Clear();
                        AuthorsMenuView.Show();
                        break;

                    case "6":
                        Console.Clear();
                        GenresMenuView.Show();
                        break;

                    case "7":
                        FindByGenresAndDate();
                        break;

                    case "8":
                        FindByAuthor();
                        break;

                    case "9":
                        FindByGenre();
                        break;

                    case "10":
                        FindByNameAndAuthor();
                        break;

                    case "11":
                        FindByHands();
                        break;

                    case "12":
                        Console.WriteLine("Введите идентификатор пользователя");
                        string id = Console.ReadLine();
                        BookOnHandsCount(id);
                        break;

                    case "13":
                        FindByLastPublishDate();
                        break;

                    case "14":
                        GetAllSortABC();
                        break;
                        
                    case "15":
                        GetAllSortPublishDate();
                        break;

                    case "0":
                        Console.Clear();
                        menuWhile = false;
                        break;

                    default:
                        AllertMessage.Show("");
                        break;
                }
                Console.WriteLine("");
            }
        }

        private static int CheckInput(string input, string message)
        {
            int i;
            while (true)
            {
                if (!int.TryParse(input, out i))
                {
                    AllertMessage.Show("");
                    Console.Write(message);
                    input = Console.ReadLine();
                }
                else break;
            }
            return i;
        }

        private static void AddBook()
        {            
            Book book = new();

            Console.Write("Название книги: ");
            book.Name = Console.ReadLine();

            string message = "Год публикации: ";
            Console.Write(message);
            book.PublishDate = new DateTime(CheckInput(Console.ReadLine(), message), 1, 1, 0, 0, 0);

            message = "Выберите автора: ";
            Console.WriteLine(message);
            AuthorsMenuView.GetAll();
            int autId = CheckInput(Console.ReadLine(), message);

            // Проверка наличия ID автора в базе
            while (true)
            {
                if (new AuthorRepository().FindById(autId) != null)
                {
                    book.AuthorId = autId;
                    break;
                }
                else
                {
                    AllertMessage.Show($"Автора с Id: {autId} нет в базе!");
                    Console.Write(message);
                    autId = CheckInput(Console.ReadLine(), message);
                }
            }

            message = "Выберите жанр: ";
            Console.WriteLine(message);
            GenresMenuView.GetAll();
            int genId = CheckInput(Console.ReadLine(), message);

            // Проверка наличия ID жанра в базе
            while (true)
            {
                if (new GenreRepository().FindById(genId) != null)
                {
                    book.GenreId = genId;
                    break;
                }
                else
                {
                    AllertMessage.Show($"Жанра с Id: {genId} нет в базе!");
                    Console.Write(message);
                    genId = CheckInput(Console.ReadLine(), message);
                }
            }
            
            BookRepository br = new();
            br.Add(book);

            SuccessMessage.Show("Запись успешна");
        }

        private static void BookList()
        {
            BookRepository br = new();
            foreach (var b in br.GetAll())
                Console.WriteLine($" {b.Id}. {b.Name}");
        }

        private static void BookFind()
        {
            Console.WriteLine("Введите название книги (или часть этих данных):");
            string name = Console.ReadLine();

            BookRepository repository = new();
            var booksList = repository.FindByName(name);

            if (booksList.Count > 0)
            {
                SuccessMessage.Show($"Найдено результатов: {booksList.Count}");
                foreach (var book in booksList)
                {
                    Console.WriteLine($"{book.Name}\n" +
                        $" Id: {book.Id}\n" +
                        $" Жанр: {book.Genre.Name}\n" +
                        $" Год публикации: {book.PublishDate.Year}\n" +
                        $" Автор: {book.Author.Name}");
                    Console.WriteLine();
                }
            }
            else
                AllertMessage.Show($"Книга {name} не найдена!");
        }

        private static void BooksOnHandInf()
        {

        }

        /// <summary>
        /// ДЕМО работы метода. Задание 25.5.4
        /// Поиск по жанру и между датами
        /// </summary>
        private static void FindByGenresAndDate()
        {
            BookRepository repository = new();
            Genre genre = new();
            genre.Id = 3;

            DateTime startDate = new DateTime(2000, 1, 1, 0, 0, 0);
            DateTime endDate = new DateTime(2009, 1, 1, 0, 0, 0);

            var models = repository.FindByGenreAndDate(genre, startDate, endDate);
            foreach (var v in models)
                Console.WriteLine($"{v.Name} (Id: {v.Id})");
        }

        /// <summary>
        /// ДЕМО работы метода. Задание 25.5.4
        /// Поиск по автору
        /// </summary>
        private static void FindByAuthor()
        {
            BookRepository repository = new();
            Author author = new();
            author.Id = 2;

            var models = repository.FindByAuthor(author);
            foreach (var v in models)
                Console.WriteLine($"{v.Name} (Id: {v.Id})");
        }

        /// <summary>
        /// ДЕМО работы метода. Задание 25.5.4
        /// Поиск по жанру
        /// </summary>
        private static void FindByGenre()
        {
            BookRepository repository = new();
            Genre genre = new();
            genre.Id = 2;

            var models = repository.FindByGenre(genre);
            foreach (var v in models)
                Console.WriteLine($"{v.Name} (Id: {v.Id})");
        }

        /// <summary>
        /// ДЕМО работы метода. Задание 25.5.4
        /// Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.
        /// </summary>
        private static void FindByNameAndAuthor()
        {
            Author author = new() { Id = 1 };
            string bookName = "Ведьмак 1";

            BookRepository repository = new();
            if (repository.FindByNameAndAuthor(bookName, author))
                SuccessMessage.Show("Такая книга с таким автором есть");
            else
                AllertMessage.Show("Такой книги с таким автором нет");
        }

        /// <summary>
        /// ДЕМО работы метода. Задание 25.5.4
        /// Получать булевый флаг о том, есть ли определенная книга на руках у пользователя.
        /// </summary>
        private static void FindByHands()
        {
            Book book = new() { Id = 2 };
            User user = new() { Id = 2 };

            BooksOnHandRepository repository = new();
            if (repository.FindByBookAndUser(book, user))
                SuccessMessage.Show($"У пользователя {user.Id} есть книга {book.Id}");
            else
                AllertMessage.Show($"У пользователя {user.Id} нет книги {book.Id}");
        }

        /// <summary>
        /// ДЕМО работы метода. Задание 25.5.4
        /// Получать количество книг на руках у пользователя
        /// </summary>
        private static void BookOnHandsCount(string sid)
        {
            int id = Convert.ToInt32(sid);
            User user = new() { Id = id };
            BooksOnHandRepository repository = new();
            Console.WriteLine($"Кол-во книг у пользователя {user.Id} = {repository.BookOnHandsCount(user)}");
        }

        /// <summary>
        /// ДЕМО работы метода. Задание 25.5.4
        /// Получение последней вышедшей книги
        /// </summary>
        private static void FindByLastPublishDate()
        {
            BookRepository repository = new();
            Book book = repository.FindByLastPublishDate();
            Console.WriteLine($"{book.Id} - {book.Name} - {book.PublishDate.Year}");
        }

        /// <summary>
        /// ДЕМО работы метода. Задание 25.5.4
        /// Получение списка всех книг, отсортированного в алфавитном порядке по названию.
        /// </summary>
        private static void GetAllSortABC()
        {
            BookRepository repository = new();

            foreach (var book in repository.GetAllSortABC())
            {
                Console.WriteLine($"{book.Id} - {book.Name} - {book.PublishDate.Year}");
            }
        }

        /// <summary>
        /// ДЕМО работы метода. Задание 25.5.4
        /// Получение списка всех книг, отсортированного в порядке убывания года их выхода.
        /// </summary>
        private static void GetAllSortPublishDate()
        {
            BookRepository repository = new();

            foreach (var book in repository.GetAllSortPublishDate())
            {
                Console.WriteLine($"{book.Id} - {book.Name} - {book.PublishDate.Year}");
            }
        }
    }
}

