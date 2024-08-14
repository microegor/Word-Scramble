using System;
using System.Xml;

class Program
{
    static void Main()
    {
        string[] words = { "hello", "wonderful", "linq", "beautiful", "world" };


        // Console.WriteLine($"Random word: {randomWord}");
        Console.WriteLine("Добро пожаловать в игру!");

        while (true)
        {
            string randomWord = RandomWord(words);
            string shuffledWord = Shuffle(randomWord);
            Console.Write("Вам нужно угадать слово из букв: ");
            Console.WriteLine(shuffledWord);
            while (true)
            {
                Console.Write("Введите ваш ответ: ");
                string answer = Console.ReadLine();
                if (answer == randomWord)
                {
                    Console.WriteLine("Поздравляю! Вы угадали слово!");
                    break;
                }
                else
                {
                    Console.WriteLine("К сожалению, вы не угадали слово. Попробуйте еще раз.");
                }
            }
            Console.WriteLine("Хотите сыграть еще раз? (да/нет)");
            string playAgain = Console.ReadLine();
            if (playAgain != "да" && playAgain != "yes" && playAgain != "y")
            {
                break;
            }
        }
    }

    static string RandomWord(string[] words)
    {
        Random random = new Random();
        int randomIndex = random.Next(0, words.Length);
        return words[randomIndex];
    }

    static string Shuffle(string word)
    {
        Random random = new Random();
        char[] characters = word.ToCharArray();
        for (int i = 0; i < characters.Length; i++)
        {
            int j = random.Next(0, characters.Length);
            char temp = characters[i];
            characters[i] = characters[j];
            characters[j] = temp;
        }
        return new string(characters);
    }
}
