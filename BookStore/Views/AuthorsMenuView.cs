using System;
using BookStore.Models;
using BookStore.Repositories;
using BookStore.Views.Messages;

namespace BookStore.Views
{
	public static class AuthorsMenuView
	{
        public static void Show()
        {
            bool menuWhile = true;
            while (menuWhile)
            {
                Console.WriteLine("Меню работы с авторамими:");
                Console.WriteLine(" 1 - Новый автор");
                Console.WriteLine(" 2 - Список всех авторов");
                Console.WriteLine(" 3 - Поиск автора");
                Console.WriteLine(" 4 - Редактировать автора");
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
            Author model = new();

            while (true)
            {               
                Console.Write("Введите имя автора: ");
                model.Name = Console.ReadLine();

                if (model.Name == string.Empty || model == null)
                    AllertMessage.Show("Ошибка ввода!");
                else break;                
            }

            AuthorRepository ar = new();
            ar.Add(model);

            SuccessMessage.Show("Запись успешна");
        }

        public static int GetAll()
        {
            AuthorRepository ar = new();
            var authors = ar.GetAll();
            foreach (var a in authors)
                Console.WriteLine($" {a.Id}. {a.Name}");
            return authors.Count();
        }

        private static void Update()
        {
            AuthorRepository ar = new();
            int id;
            while (true)
            {
                Console.Write("Введите Id автора (0 - выход): ");
                if (!int.TryParse(Console.ReadLine(), out id))
                    AllertMessage.Show("");
                else if (id == 0)
                    return;
                else
                {
                    Author author = new();
                    author = ar.FindById(id);
                    if (author != null)
                    {
                        Console.WriteLine($"Автор найден - Id: {author.Id} Name: {author.Name}");
                        Console.Write("Введите новое имя автора (0 - выход): ");
                        string input = Console.ReadLine();
                        switch(input)
                        {
                            case "0":
                                return;

                            case "":
                                AllertMessage.Show("");
                                break;

                            default:
                                author.Name = input;
                                ar.Update(author);
                                SuccessMessage.Show("Имя автора изменено");
                                return;
                                
                        }
                    }
                    else
                        AllertMessage.Show($"Автор с Id: {id} не найден!");
                }
            }
        }

        private static void FindByName()
        {           
            Console.WriteLine("Введите Имя или Фамилию (или часть этих данных):");
            string name = Console.ReadLine();

            AuthorRepository ar = new();
            var authorsList = ar.FindByName(name);

            if (authorsList.Count > 0)
            {
                SuccessMessage.Show($"Найдено результатов: {authorsList.Count}");
                foreach (var author in authorsList)
                {
                    Console.WriteLine($"{author.Name} (Id: {author.Id})");
                }
            }
            else
                AllertMessage.Show($"Автор {name} не найден!");


            
        }
    }
}

