using System;
namespace BookStore.Views.Messages
{
	public static class SuccessMessage
	{
        public static void Show(string message)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{message}\n");
            Console.ForegroundColor = originalColor;
        }
    }
}

