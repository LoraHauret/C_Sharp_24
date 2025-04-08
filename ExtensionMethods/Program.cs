/*
 
2. Практика на методы расширения (extenstion)
class Program
{
static void Main(string[] args)
{
"Hello world".Print();
2024.Print();
0.08.Print();
}
}
сделать так, чтобы этот код скомпилировался
 */

namespace ExtensionMethods
{
    public static class StringExtensions
    {
        public static string Print(this string str)
        {
            Console.WriteLine("Строка печатается в расширении: " + str);
            return str;
        }
    }
    public static class IntExtensions
    {
        public static int Print(this int number)
        {
            Console.WriteLine("Целое число печатается в расширении: " + number);
            return number;
        }
    }
    public static class DoubleExtensions
    {
        public static double Print(this double number)
        {
            Console.WriteLine("Число печатается в расширении: " + number);
            return number;
        }
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            "Hello, World!".Print();
            2024.Print();
            0.08.Print();
        }
    }
}
