using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_1.Classes.Helpers
{
    public static class InputHelper
    {
        public static int GetValidInput(string _message, int _min, int _max)
        {
            int input;

            if (!string.IsNullOrEmpty(_message))
            {
                Console.WriteLine(_message);
            }

            while (!int.TryParse(Console.ReadLine(), out input) || input < _min || input > _max)
            {
                Console.WriteLine($"Invalid input. Please enter a value between {_min} and {_max}:");
            }

            return input;
        }

        public static string ReadNonEmptyText(string _message)
        {
            string text;

            do
            {
                Console.WriteLine(_message);
                text = Console.ReadLine() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(text))
                {
                    Console.WriteLine("This field cannot be empty. Please try again.");
                }

            } while (string.IsNullOrWhiteSpace(text));

            return text;
        }
    }
}
