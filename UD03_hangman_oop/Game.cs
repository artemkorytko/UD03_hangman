using System;

namespace UD03_hangman_oop
{
    internal class Game
    {
        //основные настройки
        public static string path = @"/Users/a.korytko/TMS/Lessons_p1/Материалы для занятий/Hangman/hangman/word_rus.txt";
        public static int maxErrors = 20;

        public static void Main(string[] args)
        {
            HangmanWord word = new HangmanWord(path);
            Console.WriteLine("Давай поиграем!");
            while (true)
            {
                //загадываем слово
                word.GenerateWord();

                //создаём счётчик
                int errors = maxErrors;
                Console.WriteLine($"Загадано слово из {word.SecretWord.Length} букв. Отгадай его за {errors} попыток");

                while (errors > 0 && !word.IsSolved)
                {
                    //просим ввести букву и считываем строку
                    Console.WriteLine("Введите букву");
                    string input = Console.ReadLine();

                    //проверяем строку
                    if (input.Length == 0 || !Char.IsLetter(input[0]))
                    {
                        Console.Clear();
                        Console.WriteLine("Вводи только буквы");
                        continue;
                    }

                    Console.Clear();
                    if (word.CheckLetter(input[0]))
                    {
                        Console.WriteLine("Угадал букву!");
                    }
                    else
                    {
                        Console.WriteLine($"Такой буквы нет! Осталось попыток: {--errors}");
                    }

                    Console.WriteLine(word.ViewWord);
                }

                Console.Clear();
                if (errors == 0)
                {
                    Console.WriteLine($"Проигрышь! Это было слово - {word.SecretWord}");
                }
                else
                {
                    Console.WriteLine("Победа! ТЫ выиграл! Ура!");
                }

                Console.WriteLine("Чтобы продолжить нажмите Enter");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}