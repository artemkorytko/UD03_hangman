using System;
using System.IO;

namespace UD03_hangman
{
    internal class Program
    {
        //основные настройки
        public static string path = @"/Users/a.korytko/TMS/Lessons_p1/Материалы для занятий/Hangman/hangman/word_rus.txt";
        public static int maxErrors = 20;

        public static void Main(string[] args)
        {
            //считываем словарь
            string[] words = File.ReadAllLines(path);
            Console.WriteLine($"Words count: {words.Length}");

            Random random = new Random();

            Console.WriteLine("Hello! Let's play!");

            while (true)
            {
                //загадываем слово
                string stringWord = words[random.Next(0, words.Length)];
                Console.WriteLine(stringWord); //TODO: удалить когда закончим логику
                char[] charWord = stringWord.ToCharArray();

                //создаем счетчик
                int errors = maxErrors;
                int opennedLetters = 0;

                //формируем строку для отображенния процесса
                char[] viewWord = new char[charWord.Length];
                for (int i = 0; i < viewWord.Length; i++)
                {
                    viewWord[i] = '*';
                }

                Console.WriteLine($"Загадано слово из {charWord.Length} букв. Отгадай его за {errors} попыток");


                while (errors > 0 && opennedLetters != charWord.Length)
                {
                    //просим ввести букву и считываем строку
                    Console.WriteLine("Введите букву");
                    string inputString = Console.ReadLine();

                    //проверяем введенную строку
                    if (inputString.Length == 0 || !Char.IsLetter(inputString[0]))
                    {
                        Console.Clear();
                        Console.WriteLine("Вводите только буквы");
                        continue;
                    }

                    //проверяем если ли такая буква в слове
                    bool isLetterExist = false;
                    char checkLetter = inputString[0];
                    for (int i = 0; i < charWord.Length; i++)
                    {
                        if (charWord[i] == checkLetter)
                        {
                            isLetterExist = true;
                            opennedLetters += 1;
                            viewWord[i] = charWord[i];
                            charWord[i] = '-';
                        }
                    }

                    Console.Clear();
                    if (isLetterExist)
                    {
                        Console.WriteLine("Угадал! Есть такая буква!");
                    }
                    else
                    {
                        errors--;
                        Console.WriteLine($"Такой буквы нет! Осталось попыток: {errors}");
                    }

                    Console.WriteLine(new string(viewWord));
                }

                Console.Clear();
                if (errors == 0)
                {
                    Console.WriteLine($"Проигрышь! Это было слово - {stringWord}");
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