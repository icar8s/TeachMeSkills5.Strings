using System;
using System.IO;
using System.Linq;

class Program
{
    public static void Main(string[] args)
    {
        string line;
        Console.WriteLine("Текстовый файл :");
        try
        {
            line = Console.ReadLine() ?? "";
            Console.WriteLine();
            Console.WriteLine("Выберите действие которые собираетесь сделать со строкой");
            Console.WriteLine("\n" +
                "1. Найти слова, содержащие максимальное количество цифр\n" +
                "2. Найти самое длинное слово и определить, сколько раз оно встретилось в тексте.\n" +
                "3. Заменить цифры от 0 до 9 на слова «ноль», «один», ..., «девять»\n" +
                "4. Вывести на экран сначала вопросительные, а затем восклицательные предложения\n" +
                "5. Вывести на экран только предложения, не содержащие запятых\n" +
                "6. Найти слова, начинающиеся и заканчивающиеся на одну и ту же букву\n" +
                "7. Выйти из программы\n");
            var operation = Console.ReadLine();
            if (operation == "1")
            {
                MaxDigitCountInWords(line);
            }
            if (operation == "2")
            {
                MaxLetterCount(line);
            }
            if (operation == "3")
            {
                ReplaceDigit(line);
            }
            if (operation == "4")
            {
                QuationandExclamation(line);
            }
            if (operation == "5")
            {
                WithOutComma(line);
            }
            if (operation == "6")
            {
                SameStartingAndEndingLetter(line);
            }
            if (operation == "7")
            {
                Console.ReadLine();
            }
        }


        catch (Exception e)
        {
            Console.WriteLine("Ошибка :" + e.Message);
        }
    }

    static void MaxDigitCountInWords(string line)
    {
        string[] words = line.Split(new[] { ' ', ',', '.', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);
        var count = 0;
        foreach (string word in words)
        {
            var digitcount = word.Count(char.IsDigit);
            if (digitcount > count)
            {
                count = digitcount;
            }
        }
        var WordsWithMaxDigit = words.Where(word => word.Count(char.IsDigit) == count);
        var wordsWithMaxDigits = words.Where(word => word.Count(char.IsDigit) == count);

        Console.WriteLine($"Слова с максимальным количеством цифр ({count}):");
        {
            foreach (var word in wordsWithMaxDigits)
            {
                Console.WriteLine(word);
            }
        }
    }

    static void MaxLetterCount(string line)
    {
        string[] words = line.Split(new[] { ' ', ',', '.', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);
        var CountLongestWord = 0;
        var longestWord = "";
        foreach (var word in words)
        {
            if (word.Length > CountLongestWord)
            {
                longestWord = word;
                CountLongestWord = word.Length;
            }
        }

        int countofword = words.Count(word => word.Equals(longestWord));

        Console.WriteLine($"Самое длинное слово: {longestWord}");
        Console.WriteLine($"Количество вхождений: {countofword}");
    }
    static void ReplaceDigit(string line)
    {
        string[] digits = {"1","2","3","4", "5", "6", "7", "8","9"};
        string[] digit = { "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
        for(int i = 0; i < digits.Length; i++) 
        {
            line = line.Replace(digits[i], digit[i]);
        }
        Console.WriteLine("Измененный текст - ");
        Console.WriteLine(line);
    }
    static void QuationandExclamation(string line)
    {
        string[] sentences = line.Split(new[] {'.','!','?'});
        foreach(var sentence in sentences) 
        {
            if (!string.IsNullOrWhiteSpace(sentence) && sentence.EndsWith("?"))
            {
                Console.WriteLine(sentence.Trim());
            }
        }
        foreach (var sentence in sentences)
        {
            if (!string.IsNullOrWhiteSpace(sentence) && sentence.EndsWith("!"))
            {
                Console.WriteLine(sentence.Trim());
            }
        }
    }
    static void WithOutComma(string line)
    {
        string[] sentences = line.Split(new[] { '.', '!', '?' });
        foreach (var sentence in sentences)
        {
            if (!sentence.Contains(","))
            {
                Console.WriteLine(sentence.Trim());
            }
        }
    }
    static void SameStartingAndEndingLetter(string line)
    {
        string[] words = line.Split(new[] { ' ', ',', '.', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var word in words)
        {
            if (word[0] == word[word.Length-1])
            {
                Console.WriteLine(word);
            }
        }
    }
}

