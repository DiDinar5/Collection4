
using System.Text.RegularExpressions;

namespace Collectiontest
{
    class Program
    {
        static void Main(string[] args)
        {
            string x = Console.ReadLine();
            string txt = File.ReadAllText(x);

            // Использование регулярных выражений для замены символов
            // это не буквы или числа с пробелами.
            Regex reg_exp = new Regex("[^а-яА-Я0-9]");
            txt = reg_exp.Replace(txt, " ");

            // Разделить текст на слова.
            string[] words = txt.Split(
                new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            // Используйте LINQ для получения уникальных слов.
            var word_query =
                (from string word in words
                 orderby word
                 select word).Distinct();

            // Отображение результата.
            string[] result = word_query.ToArray();
            Array.Sort(result);
            foreach (string s in result)
                if (s.Length > 18)
                    Console.WriteLine(s.Length + s);
        }
    }
}