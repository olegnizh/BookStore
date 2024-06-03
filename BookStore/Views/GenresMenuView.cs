using System;
using BookStore.Models;
using BookStore.Repositories;
using BookStore.Views.Messages;

namespace BookStore.Views
{
	public static class GenresMenuView
	{
        public static void Show()
        {
            bool menuWhile = true;
            while (menuWhile)
            {
                Console.WriteLine("Меню работы с жанрами:");
                Console.WriteLine(" 1 - Новый жанр");
                Console.WriteLine(" 2 - Список всех жанров");
                Console.WriteLine(" 3 - Поиск жанра");
                Console.WriteLine(" 4 - Редактировать жанр");
                Console.WriteLine(" 0 - Назад");
                Console.WriteLine("");

                switch (Console.ReadLine())
                {
                    case "1":
                        Add();
                        break;

                    case "2":
                        GetAll();
                        break;

                    case "3":
                        FindByName();
                        break;

                    case "4":
                        Update();
                        break;

                    case "0":
                        Console.Clear();
                        menuWhile = false;
                        break;

                    default:
                        Console.WriteLine("Ошибка ввода");
                        break;
                }
                Console.WriteLine("");
            }
        }

        private static void Add()
        {
            Genre model = new();
            while (true)
            {
                Console.Write("Введите имя жанра: ");
                model.Name = Console.ReadLine();

                if (model.Name == string.Empty || model == null)
                    AllertMessage.Show("Ошибка ввода!");
                else break;
            }

            GenreRepository gr = new();
            gr.Add(model);

            SuccessMessage.Show("Запись успешна");
        }

        public static int GetAll()
        {
            GenreRepository gr = new();
            var genres = gr.GetAll();

            foreach (var a in genres)
                Console.WriteLine($" {a.Id}. {a.Name}");

            return genres.Count();
        }

        private static void Update()
        {
            GenreRepository gr = new();
            int id;
            while (true)
            {
                Console.Write("Введите Id жанра (0 - выход): ");
                if (!int.TryParse(Console.ReadLine(), out id))
                    AllertMessage.Show("");
                else if (id == 0)
                    return;
                else
                {
                    Genre genre = new();
                    genre = gr.FindById(id);
                    if (genre != null)
                    {
                        Console.WriteLine($"Жанр найден - Id: {genre.Id} Name: {genre.Name}");
                        Console.Write("Введите новое имя жанра (0 - выход): ");
                        string input = Console.ReadLine();
                        switch (input)
                        {
                            case "0":
                                return;

                            case "":
                                AllertMessage.Show("");
                                break;

                            default:
                                genre.Name = input;
                                gr.Update(genre);
                                SuccessMessage.Show("Имя жанра изменено");
                                return;

                        }
                    }
                    else
                        AllertMessage.Show($"Жанр с Id: {id} не найден!");
                }
            }
        }

        private static void FindByName()
        {
            Console.WriteLine("Введите название жанра (или часть этих данных):");
            string name = Console.ReadLine();

            GenreRepository gr = new();
            var genresList = gr.FindByName(name);

            if (genresList.Count > 0)
            {
                SuccessMessage.Show($"Найдено результатов: {genresList.Count}");
                foreach (var genre in genresList)
                {
                    Console.WriteLine($"{genre.Name} (Id: {genre.Id})");
                }
            }
            else
                AllertMessage.Show($"Жанр {name} не найден!");



        }
    }
}

