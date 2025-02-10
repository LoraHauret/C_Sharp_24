//Console.WriteLine("Hello, World!");
//string name = "Мурзик";
//string name1 = "Barsik";
//Console.WriteLine(name);
//Console.WriteLine(name1);
//name = (string)name1.Clone();
//name1 = "Tuzik";
//Console.WriteLine(name);
//Console.WriteLine(name1);
//using Extreme.Numerics;
using System;
using Numerics.NET;
//using Numerics.NET.Calculus;

namespace Lesson4
{
    class ArabToRomanConverter
    {        

       private static string GetRomanRepresantation(int digit, string[] arr)
        {
            string ret = "";
            if (digit == 9)
            {
                ret += arr[0] + arr[2];
            }
            else if (digit >= 5)
            {
                ret += arr[1];
                for (int j = 0; j < digit % 5; j++)
                {
                    ret += arr[0];
                }
            }
            else if (digit == 4)
            {
                ret += arr[0] + arr[1];
            }
            else
            {
                for (int j = 0; j < digit; j++)
                {
                    ret += arr[0];
                }
            }
            return ret;
        }

       private static string ConvertToRoman(int val)
        {
            string ret = "";
            string[] ones = { "I", "V", "X" };
            string[] tens = { "X", "L", "C" };
            string[] hundreds = { "C", "D", "M" };

            string temp = val.ToString();

            for (int i = 0; i < temp.Length; i++)
            {
                int digit = temp[i] - '0'; // текущая цифра. Поскольку нуля в римской системе нет, то ноль не учитывается
                switch (temp.Length - i) // разряд
                {
                    case 4: // тысячи
                        for (int j = 0; j < digit; j++)
                        {
                            ret += "M";
                        }
                        break;
                    case 3:// сотни
                        ret += GetRomanRepresantation(digit, hundreds);
                        break;
                    case 2:  // десятки
                        ret += GetRomanRepresantation(digit, tens);
                        break;
                    case 1:   // единицы
                        ret += GetRomanRepresantation(digit, ones);
                        break;
                }
            }

            return ret;
        }
       public static void ProcessRomanDigits()
        {
            int COUNT = 4000;
            string[] romanDigits = new string[COUNT];
            for (int i = 0; i < romanDigits.Length; i++)
            {
                romanDigits[i] = ConvertToRoman(i + 1);
                Console.WriteLine(romanDigits[i]);
            }
        }

     }

    class DigitVocalizer
    {
        private static void VocalizeDigits(int val)
        {
            string[] ones = { "ноль", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять", "одна", "две" };
            string[] tens = { "десять", "одиннадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать" };
            string[] dozens = { "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто" };
            string[] hundreds = { "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" };
            string[] thousands = { "тысяча", "тысячи", "тысяч" };
            string[] millions = { "миллион", "миллиона", "миллионов" };
            string temp = val.ToString();

            for (int i = 0; i < temp.Length; i++)
            {
                int digit = temp[i] - '0'; // текущая цифра
                if (digit == 0 && temp.Length == 1) // отдельный случай для нуля
                {
                    Console.Write(ones[digit] + " ");
                }
                else
                { 
                    switch (temp.Length - i) // разряд
                    {
                        case 7: // миллионы (единицы)
                            if (digit != 0)
                            {
                                if (digit == 1)
                                {
                                    Console.Write(ones[ones.Length - 2] + " ");
                                    Console.Write(millions[0] + " ");
                                }
                                else if (digit >= 5)
                                {
                                    Console.Write(ones[digit] + " ");
                                    Console.Write(millions[2] + " ");
                                }
                                else if (digit > 1)
                                {
                                    Console.Write(ones[digit] + " ");
                                    Console.Write(millions[1] + " ");
                                }
                                else
                                {
                                    Console.Write(ones[digit] + " ");
                                    Console.Write(millions[2] + " ");
                                }
                            }
                            break;
                        case 6: // сотни тысяч
                            if (digit != 0)
                                Console.Write(hundreds[digit - 1] + " ");
                            break;
                        case 5: // десятки тысяч
                            if (digit != 0)
                            {
                                if (digit == 1)
                                {
                                    Console.Write(tens[temp[i + 1] - '0'] + " " + thousands[2]);
                                    i++;
                                }
                                else
                                {
                                    Console.Write(dozens[digit - 2] + " ");
                                }
                            }
                            break;
                        case 4: // тысячи

                            switch (digit)// анализ текущей цифры
                            {
                                case 1: //
                                    Console.Write(ones[ones.Length - 2] + " ");
                                    Console.Write(thousands[0] + " ");
                                    break;
                                case 2:
                                    Console.Write(ones[ones.Length - 1] + " ");
                                    Console.Write(thousands[1] + " ");
                                    break;
                                case 3:
                                case 4:
                                    Console.Write(ones[digit] + " ");
                                    Console.Write(thousands[1] + " ");
                                    break;
                                default:
                                    if (digit != 0)
                                        Console.Write(ones[digit] + " ");
                                    Console.Write(thousands[2] + " ");
                                    break;
                            }
                            break;
                        case 3:// сотни
                            if (digit != 0)
                                Console.Write(hundreds[digit - 1] + " ");
                            break;
                        case 2:  // десятки
                            if (digit != 0) // если десятки не равны нулю
                            {

                                if (digit == 1)
                                {
                                    Console.Write(tens[temp[i + 1] - '0'] + " ");
                                    i++;
                                }
                                else
                                {
                                    Console.Write(dozens[digit - 2] + " ");
                                }
                            }
                            break;
                        case 1:   // единицы
                            if (digit != 0)
                            {
                                Console.Write(ones[digit] + " ");
                            }
                            break;
                    }
                }
            }
        }

        public static void ProcessVocalizeDigits()
        {
            Console.Write("Введите число: ");
            string temp = Console.ReadLine();

            int number;
            while (!int.TryParse(temp, out number))
            {
                Console.WriteLine("Ошибка ввода! Попробуйте еще раз.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Введите число: ");               
                temp = Console.ReadLine();
            }
            Console.Clear();
            Console.Write(temp + " - ");
            VocalizeDigits(number);

            //for (int i = 9999; i < 100000; i++)
            //{
            //    Console.Write(i + " - ");
            //    VocalizeDigits(i);
            //    Console.WriteLine();
            //}
        }
    }

    class LookAndSayAlgorythm
    {             
        private static string LookAndSay(string str)
        {
            string ret = "";
            int count = 1;
            for (int i = 0; i < str.Length; i++)
            {
                if (i + 1 < str.Length && str[i] == str[i + 1])
                {
                    count++;
                }
                else
                {
                    ret += count.ToString() + str[i];
                    count = 1;
                }
            }
            return ret;
        }
        private static void PrintNthsequence(int n)
        {
            string temp = "1";
            for (int i = 0; i < n; i++)
            {
                temp = LookAndSay(temp);                
            }
            Console.WriteLine(temp);
        }
        public static void ProcessLookAndSay()
        {
            Console.Write("Введите число последовательности: ");
            string temp = Console.ReadLine();

            int number;
            while (!int.TryParse(temp, out number))
            {
                Console.WriteLine("Ошибка ввода! Попробуйте еще раз.");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Введите число последовательности: ");
                temp = Console.ReadLine();
            }

            for (int i = 0; i < number; i++)
            {
                PrintNthsequence(i);
            }
        }
    }

    class Matrix
    {
        private static int MinElement(int[] arr)
        {
            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
            }
            return min;
        }
        public static void Print2Array(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.Write("\t");
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if(arr[i, j] / 10 == 0)
                        Console.Write(arr[i, j] + "  ");
                    else
                        Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
        }
        public static void GetArray(out int[,] arr)
        {
            Console.Write("Введите размерности массива.\nКоличество рядов: ");
            int row = int.Parse(Console.ReadLine());
            Console.Write("Количество столбцов: ");
            int col = int.Parse(Console.ReadLine());
            arr = new int[row, col];            
        }
        static public void ProcessWaveArray(ref int[,] arr)
        {
            int k;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    k = i % 2;
                    arr[i, j] = (i + k) * arr.GetLength(1) + (j *(1-(k<<1))) + (k ^ 1);
                }
            }
        }
      
        static public void ProcessArray(ref int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = i * arr.GetLength(1) + j + 1;
                }
            }
        }

        public static void ProcessSpiralArray(ref int[,] arr)
        {
            int k, curValue;
            int row = arr.GetLength(0);
            int col = arr.GetLength(1);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    k = MinElement(new int[] { i, row - i - 1, j, col - j - 1 });
                    curValue = (int) Math.Pow((row - 2 * k), 2);
                    int offset;
                    if(i==k)
                        offset = j - k;
                    else if (j == row-k-1)
                        offset = row - 2 * k + i - k - 1;
                    else if (i == row - k - 1)
                        offset = 3 * row - 5 * k - j- 3;
                    else
                        offset = 3 *(row - 2 * k -1) + (row -k -1 -i);
                    arr[i, j] = curValue - offset;
                }
            }
        }
        
        public static void ProcessSpheareInCubeArray()
        {
                int N = 9;  
                int[,,] cube = new int[N, N, N];

                int center = N / 2;
                int radius = N / 2;

                for (int x = 0; x < N; x++)
                {
                    for (int y = 0; y < N; y++)
                    {
                        for (int z = 0; z < N; z++)
                        {
                            if ((x - center) * (x - center) + (y - center) * (y - center) + (z - center) * (z - center) <= radius * radius)
                            {
                                cube[x, y, z] = 1;  // Точка внутри шара

                            }
                        }
                    }
                }

                for (int z = 0; z < N; z++)
                {
                    Console.WriteLine($"Слой {z + 1}:");
                    for (int x = 0; x < N; x++)
                    {
                        for (int y = 0; y < N; y++)
                        {
                            Console.Write(cube[x, y, z] + " ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
        }
    }    


    class StringTasks
    {
        public static void ProssesPalindromString()
        {
            Console.Write("Введите строку: ");
            string str = Console.ReadLine();

            char[] chars = " ,.!?".ToCharArray();
            string temp = str.ToLower();

            foreach (var item in chars)
                temp = temp.Replace(item, ' ');

            temp = temp.Replace(" ", "");

            bool isPalindrom = true;

            for (int i = 0; i < temp.Length / 2; i++)
            {
                if (temp[i] != temp[temp.Length - i - 1])
                {
                    isPalindrom = false;
                    break;
                }
            }
            if (isPalindrom)
                Console.WriteLine($"Строка \"{str}\" ЯВЛЯЕТСЯ палиндромом.");
            else
                Console.WriteLine($"Строка \"{str}\" НЕ является палиндромом.");
        }

        public static void ProcessStringStatistic()
        {
            Console.Write("Введите строку: ");
            string str = Console.ReadLine();
            int symbols = str.Length;

            string temp = str.Trim();
            if (temp.Length == 0)
            {
                Console.WriteLine("Строка пуста.");
                return;
            }

            int words = 0, vowels = 0, consonants = 0, digits = 0, punctuation = 0, othersymb = 0;


            words = temp.Split(' ').Length;

            temp = temp.Replace(" ", "").ToLower();
            for (int i = 0; i < temp.Length; i++)
            {
                if (char.IsDigit(temp[i]))
                    digits++;
                else if (char.IsLetter(temp[i]))
                {
                    if ("aeiouyаеёиоуыэюя".Contains(temp[i]))
                        vowels++;
                    else
                        consonants++;
                }
                else if (char.IsPunctuation(temp[i]))
                    punctuation++;
                else
                    othersymb++;
            }
            Console.WriteLine($"Количество слов: {words}");
            Console.WriteLine($"Общее количество символов: {symbols}");
            Console.WriteLine($"Количество гласных: {vowels}");
            Console.WriteLine($"Количество согласных: {consonants}");
            Console.WriteLine($"Количество цифр: {digits}");
            Console.WriteLine($"Количество знаков пунктуации: {punctuation}");
            Console.WriteLine($"Количество прочих символов: {othersymb}");
        }

        //  А роза, упала, не !на лапу Азора. ?><< 
        private static string RemovePunctuation(string str)
        {
            string ret = str;
            int i = 0;
            while (i < ret.Length)
            {
                if (!char.IsLetter(ret[i]))
                    ret = ret.Replace(ret[i].ToString(), "");
                i++;
            }
            return ret;
        }

        private static string GetSortedString(string str)
        {
            string ret = str.ToLower();
            ret = RemovePunctuation(ret);
            var temp = ret.ToCharArray();
            Array.Sort(temp);
            return new string(temp);
        }

        //Аз есмь строка, живу я, мерой остр.
        //За семь морей ростка я вижу рост!
        public static void ProcessStringAnagramm()
        {
            Console.Write("Введите 1 строку: ");
            string str1 = Console.ReadLine();
            Console.Write("Введите 2 строку: ");
            string str2 = Console.ReadLine();
            // Console.WriteLine(GetSortedString(str1));
            //Console.WriteLine(GetSortedString(str2));

            if (GetSortedString(str1).ToLower() == GetSortedString(str2).ToLower())
                Console.WriteLine("Строки ЯВЛЯЮТСЯ анаграммами.");
            else
                Console.WriteLine("Строки НЕ являются анаграммами.");

        }
        private static string Swap(string str, int i, int j)
        {
            char[] temp = str.ToCharArray();
            char t = temp[i];
            temp[i] = temp[j];
            temp[j] = t;
            return new string(temp);
        }
        private static void GetPermutation(string str, int start, List<string> res)
        {
            if (start == str.Length - 1)
            {
                res.Add(str);
                return;
            }

            List<char> usedLetters = new List<char>();


            for (int i = start; i < str.Length; i++)
            {
                if (usedLetters.Contains(str[i]))
                    continue;

                usedLetters.Add(str[i]);

                str = Swap(str, start, i);
                GetPermutation(str, start + 1, res);
            }
        }
        public static void ProcessLetterPermutation()
        {
            Console.Write("Введите строку: ");
            string str = Console.ReadLine();
            string temp = str; //"AABb";
            temp = RemovePunctuation(temp);
            List<string> permutations = new List<string>();
            GetPermutation(temp, 0, permutations);
            foreach (string el in permutations)
            {
                Console.WriteLine(el);
            }
        }

        public static void ProcessSearchInPI()
        {
            AccuracyGoal goal = AccuracyGoal.Absolute(1000000);
            BigFloat pi = BigFloat.GetPi(goal);
            string piStr = pi.ToString();
            int ind = 0;
            ind = piStr.IndexOf("9", ind);
            int count = 0;
            Console.WriteLine($"9 встречается на позиции:");
            while (ind != piStr.LastIndexOf('9'))
            {
                int curInd = piStr.IndexOf("9", ind + 1);
                
                if (ind != -1)
                {
                    count = curInd - ind - 1;
                    Console.WriteLine($"{ind} и {curInd} через {count} символов.");
                }
                ind = curInd;
            }
           Console.WriteLine(piStr);
        }
    }

    class Program
    {
        static BigFloat Arctan(int p, int binaryDigits)
        {
            BigInteger power = BigInteger.Pow(2, binaryDigits) / p;
            BigInteger result = power;
            bool subtract = true;
            int k = 0;
            while (!power.IsZero)
            {
                k++;
                power /= (p * p);
                if (subtract)
                    result -= power / (2 * k + 1);
                else
                    result += power / (2 * k + 1);
                subtract = !subtract;
            }
            return BigFloat.ScaleByPowerOfTwo(new BigFloat(result), -binaryDigits);
        }
        static void Main()
        {           
            Console.WriteLine("1.Создать массив строк на 4000 элементов.Заполнить его римскими числами от 1 до\r\n3999, показать на экране все элементы.");
            ArabToRomanConverter.ProcessRomanDigits();
            Console.WriteLine();
            Console.WriteLine("2.Ввести число в диапазоне от 0 до 1000000.Озвучить его словами. Например, при\r\nвводе числа 25 вывести на экране «двадцать пять».");
            DigitVocalizer.ProcessVocalizeDigits();
            Console.WriteLine();
            Console.WriteLine("3.Дана последовательность: 1, 11, 21, 1211, 111221, 312211, 13112221, Ввести число N.Показать - ный по счёту элемент последовательности.");
            LookAndSayAlgorythm.ProcessLookAndSay();
            Console.WriteLine();
  
             int[,] arr ;

             #region

             Console.WriteLine("создание, заполнение массива в обычном порядке. Распечатка массива: ");
             Matrix.GetArray(out arr);
             Matrix.ProcessArray(ref arr);
             Matrix.Print2Array(arr);

             Console.WriteLine("\nЗаполнение того же массива в волновом порядке. Распечатка массива: ");
             Matrix.ProcessWaveArray(ref arr);
             Matrix.Print2Array(arr);

             Console.WriteLine("\nЗаполнение того же массива в спиральном порядке. Распечатка массива: ");
             Matrix.ProcessSpiralArray(ref arr);
             Matrix.Print2Array(arr);
                 #endregion

           int[,] arr1 = new int[5,5];


             Console.WriteLine("шар в кубе, разрезанный на слои:");
             Matrix.ProcessSpheareInCubeArray();
            
            /*
             1. Дана строка символов. Необходимо проверить, является ли эта строка палиндромом. Примеры палиндромов:

Ешь немытого ты меньше.
А роза упала на лапу Азора.
А роза упала не на лапу Азора.
Лёша на полке клопа нашёл.
У лип Лёша нашёл пилу.
Нажал кабан на баклажан.
Я так нежен, Катя.
На вид енот - это не диван!

             */
            Console.WriteLine("Задача на выяснение является ли строка палиндромом.");
            StringTasks.ProssesPalindromString();

            /*
             2. Написать программу, подсчитывающую количество слов, гласных и согласных букв в строке, введёной пользователем. Дополнительно выводить количество знаков пунктуации, цифр и др. символов. Пример вывода программы:

Всего символов – 38, из них:
Слов – 6
Гласных - 12
Согласных - 24
Знаков пунктуации - 2
Цифр – 0
Др. символов – 0
             */
            Console.WriteLine("Задача на подсчет статистических данных в строке.");
            StringTasks.ProcessStringStatistic();

            /*
             * 3. Написать программу, проверяющую, является ли одна строка анаграммой для другой строки (строка может состоять из нескольких слов и символов пунктуации). Пробелы и пунктуация, разница в больших и маленьких буквах должны игнорироваться. Обе строки вводятся с клавиатуры.

Пример анаграммы:
Аз есмь строка, живу я, мерой остр. 
За семь морей ростка я вижу рост!
             */
            Console.WriteLine("Задача на строку-анаграмму.");
            StringTasks.ProcessStringAnagramm();
        /*4. Напишите программу, которая выведет на экран все перестановки символов в исходной строке. Избежать повторений при перестановках. Примерами перестановки строки "AAB" могут быть "AAB", "ABA" и "BAA".*/
          StringTasks.ProcessLetterPermutation();

            /*5. Напишите программу, которая найдет макисмальное количество цифр, расположенных между двумя девятками в числе Pi. Ограничить этот поиск одним миллионом знаков после запятой. Например: в начале числа Pi, между двумя девятками находятся 6 чисел, потом одно и т.д. 3,1415 9 265358 9 7 9 323846 
http://habrahabr.ru/post/179829/
*/
            Console.WriteLine("5. Напишите программу, которая найдет макисмальное количество цифр, расположенных между двумя девятками в числе Pi. Ограничить этот поиск одним миллионом знаков после запятой. Например: в начале числа Pi, между двумя девятками находятся 6 чисел, потом одно и т.д. 3,1415 9 265358 9 7 9 323846 \nНажмите ввод");
            Console.ReadLine();
          Numerics.NET.License.Verify("57552-44390-24458-42385");
          StringTasks.ProcessSearchInPI();
           
        }
    }
       

   
}

