using System;
using System.IO;
using System.Text;

namespace Task2_24
{
    class Program
    {
        static void Main(string[] args)
        {
            String text = Read_from_file("C:\\Users\\User\\source\\repos\\Task2_24\\Task2_24\\input.txt");
            String res = func(text);
            Write_to_file("C:\\Users\\User\\source\\repos\\Task2_24\\Task2_24\\output.txt", res);

            //Тестовые данные для вывода в консоли:
            String test = "Hello, my name is Olya.. Привет, меня зовут Оля. I'm 20 years old, I'm a student! Я студент. ***";
            Console.WriteLine("Исходный текст: " + "\n" + test);
            String res_test = func(text);
            Console.WriteLine();
            Console.WriteLine("Результат: " + "\n" + res_test);
        }
        static String Read_from_file(string file_name) 
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var sr = new StreamReader(file_name, Encoding.GetEncoding("windows-1251"));
            String file = sr.ReadLine();
            return file;
        }
        static void Write_to_file(string file_name, String res) 
        {
            File.Create(file_name).Close();
            File.WriteAllText(Path.Combine(file_name), res);
        }
        static String func(String text) 
        {
            string[] words = text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            String res = "";
            char[] chars = { ' ' };
            for (int i = 0; i < words.Length-1; i++)
            {
                words[i] = words[i].Trim(chars);
                words[i] += ".\n";
                res += words[i];
            }
            words[words.Length - 1] = words[words.Length - 1].Trim(chars);

            if (words[words.Length-1].Contains('.'))
            {
                words[words.Length - 1] += ".\n";
                res += words[words.Length - 1];
            }
            else
            {
                res += words[words.Length - 1];
            }
            return res;
        }
    }
}
