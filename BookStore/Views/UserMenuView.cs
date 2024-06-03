using System;
using BookStore.Models;
using BookStore.Repositories;
using BookStore.Views.Messages;

namespace BookStore.Views
{
	public static class UserMenuView
	{
		public static void Show()
		{
            bool menuWhile = true;
            while (menuWhile)
            {
                Console.WriteLine("Меню работы с пользователями:");
                Console.WriteLine(" 1 - Новый пользователь");
                Console.WriteLine(" 2 - Список всех пользователей");
                Console.WriteLine(" 3 - Поиск пользователя");
                Console.WriteLine(" 4 - Редактировать пользователя");
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
                        AllertMessage.Show("");
                        break;
                }
                Console.WriteLine("");
            }
        }

        private static string CheckInput(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (input == string.Empty || input == null)
                    AllertMessage.Show("");
                else
                    return input;
            }
        }

        private static void Add()
        {
            User model = new();

            string message = "Введите имя пользователя: ";
            model.Name = CheckInput(message);

            message = "Введите email пользователя: ";
            model.Email = CheckInput(message);

            UserRepository repository = new();
            repository.Add(model);

            SuccessMessage.Show("Запись успешна");
        }        

        private static void GetAll()
        {
            UserRepository repository = new();

            foreach (var user in repository.GetAll())
                Console.WriteLine($" Id: {user.Id} - {user.Name} {user.Email}");
        }

        private static void Update()
        {
            UserRepository repository = new();
            int id;
            while (true)
            {
                Console.Write("Введите Id пользователя (0 - выход): ");
                if (!int.TryParse(Console.ReadLine(), out id))
                    AllertMessage.Show("");
                else if (id == 0)
                    return;
                else
                {
                    User user = new();
                    user = repository.FindById(id);
                    if (user != null)
                    {
                        Console.WriteLine($"Пользователь найден - Id: {user.Id} Name: {user.Name} Email: {user.Email}");
                        Console.Write("Введите новое имя пользователя (0 - выход): ");
                        string input = Console.ReadLine();
                        switch (input)
                        {
                            case "0":
                                return;

                            case "":
                                AllertMessage.Show("");
                                break;

                            default:
                                user.Name = input;
                                repository.Update(user);
                                SuccessMessage.Show("Имя пользователя изменено");
                                return;
                        }
                    }
                    else
                        AllertMessage.Show($"Пользователь с Id: {id} не найден!");
                }
            }
        }

        private static void FindByName()
        {
            Console.WriteLine("Введите имя пользователя (или часть этих данных):");
            string name = Console.ReadLine();

            UserRepository repository = new();
            var usersList = repository.FindByName(name);

            if (usersList.Count > 0)
            {
                SuccessMessage.Show($"Найдено результатов: {usersList.Count}");
                foreach (var user in usersList)
                {
                    Console.WriteLine($"{user.Name} (Id: {user.Id}) {user.Email}");
                }
            }
            else
                AllertMessage.Show($"Пользователь {name} не найден!");



        }
    }
}

