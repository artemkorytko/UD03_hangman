using System;
using System.IO;

namespace UD03_hangman_oop
{
    public class HangmanWord
    {
        private string[] _words;
        private string _word;
        private char[] _charWord;
        private char[] _viewWord;

        private int _openedLetters;

        public bool IsSolved => _openedLetters == _charWord.Length;
        public string SecretWord => _word;
        public string ViewWord => new string(_viewWord);

        /// <summary>
        /// Создаём словарь слов
        /// </summary>
        /// <param name="path">путь к исходному файлу</param>
        public HangmanWord(string path)
        {
            _words = File.ReadAllLines(path);
        }

        
        /// <summary>
        /// Генерируем рандомное слово
        /// </summary>
        public void GenerateWord()
        {
            // Random random = new Random();
            // int index = random.Next(0, _words.Length);
            // _word = _words[index];
            _word = _words[new Random().Next(0, _words.Length)];
            _charWord = _word.ToCharArray();
            _viewWord = new char[_charWord.Length];
            _openedLetters = 0;
            for (int i = 0; i < _charWord.Length; i++)
            {
                _viewWord[i] = '*';
            }
        }

        /// <summary>
        /// проверка на наличие буквы в загаданном слове
        /// </summary>
        /// <param name="letter">буква которую ввёл пользователь</param>
        /// <returns>да если есть такая буква</returns>
        public bool CheckLetter(char letter)
        {
            bool isLetterExist = false;

            for (int i = 0; i < _charWord.Length; i++)
            {
                if (_charWord[i] == letter)
                {
                    _openedLetters++;
                    isLetterExist = true;
                    _viewWord[i] = _charWord[i];
                    _charWord[i] = '-';
                }
            }

            return isLetterExist;
        }
    }
}