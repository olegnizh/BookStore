using System;
namespace BookStore.Views.Messages
{
	public static class AllertMessage
	{
		public static void Show(string message)
		{
			if (message == string.Empty)
				message = "Ошибка ввода";

            ConsoleColor originalColor = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{message}\n");
            Console.ForegroundColor = originalColor;
        }
	}
}

