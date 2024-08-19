using System;
using System.Xml;


class Program
{
    static void Main(string[] args)
    {
        // читаем опциональный аргумент путь к файлу со словами (разделенными разрывом строки)
        string[] defaultWords = { "hello", "wonderful", "linq", "beautiful", "world", "programming", "computer", "science", "algorithm", "software", "developer", "coding", "debugging", "testing", "database", "network", "security", "web", "application", "mobile", "apple", "banana", "chocolate", "coffee", "diamond", "elephant", "flower", "guitar", "happiness", "island", "jazz", "kangaroo", "lemon", "mountain", "notebook", "ocean", "piano", "queen", "rainbow", "sunshine", "tiger", "umbrella", "victory", "watermelon", "xylophone", "yoga", "zebra", "airplane", "butterfly", "cactus", "dolphin", "elephant", "fireworks", "giraffe", "honey", "ice cream", "jungle", "kiwi", "laptop", "moon", "night", "oasis", "penguin", "quilt", "rain", "sunset", "tulip", "unicorn", "volcano", "waterfall", "xylophone", "yacht", "zeppelin", "astronaut", "ballet", "carnival", "dandelion", "eclipse", "firefly", "garden", "harmony", "island", "jigsaw", "kite", "lighthouse", "mango", "nightingale", "ocean", "paradise", "quicksilver", "rainbow", "sunflower", "thunder", "umbrella", "violet", "water", "xylophone", "yoga", "zebra" };
        string path = args.Length > 0 ? args[0] : null;
        string[] words = path != null ? System.IO.File.ReadAllLines(path) : defaultWords;


        // Console.WriteLine($"Random word: {randomWord}");
        Console.WriteLine("Добро пожаловать в игру!");

        while (true)
        {
            int attempts = 0;
            string randomWord = RandomWord(words);
            string shuffledWord = Shuffle(randomWord);
            Console.Write("Вам нужно угадать слово из букв: ");
            Console.WriteLine(shuffledWord);
            while (true)
            {

                Console.Write("Введите ваш ответ: ");
                string answer = Console.ReadLine();
                attempts++;
                if (answer == randomWord)
                {
                    Console.WriteLine("Поздравляю! Вы угадали слово!");
                    break;
                }
                else
                {
                    if (attempts == 5)
                    {
                        Console.WriteLine("Вы проиграли! Правильный ответ: " + randomWord);
                        break;
                    }
                    Console.WriteLine("К сожалению, вы не угадали слово. Попробуйте еще раз.");
                }
                if (answer == ":q")
                {
                    Console.WriteLine("Правильный ответ: " + randomWord);
                    break;
                }
            }
            Console.WriteLine($"Количество попыток: {attempts}");
            Console.Write("Хотите сыграть еще раз? (да/нет): ");
            string playAgain = Console.ReadLine();
            if (playAgain != "да" && playAgain != "yes" && playAgain != "y")
            {
                break;
            }
            Console.WriteLine("----------------------------------------");
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
