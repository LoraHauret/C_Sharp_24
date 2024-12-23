namespace Stairs
{
    class Lesson
    {
        static void DrawStairs(int stepCount, int minLength)
        {
            int countGaps = 0;
            for (int i = 0; i < stepCount * 2; i++)
            {
                for (int j = 0; j < countGaps; j++)
                    Console.Write(" ");

                if (i == 0 || i % 2 == 0)
                {
                    for (int j = 0; j < minLength; j++)
                        Console.Write("*");
                    countGaps += minLength - 1;
                }
                else
                    Console.Write("*");
                Console.WriteLine();
            }
        }

        static void DrawExtendedStairs(int stepCount, int minLength)
        {
            int countGaps = 0;
            for (int i = 0; i < stepCount * 2; i++)
            {
                Console.Write("  *");
                for (int j = 0; j < countGaps; j++)
                    Console.Write(" ");

                if (i == 0 || i % 2 == 0)
                {
                    for (int j = 0; j < minLength; j++)
                        Console.Write("*");
                    countGaps += minLength - 1;
                }
                else
                    Console.Write("*");
                Console.WriteLine();
            }
            Console.Write("  *");
            for (int i = 0; i < (minLength - 1) * (stepCount - 1) + minLength; i++)
                Console.Write("*");
        }

        static void Main()
        {
            Console.Write("Укажите количество ступенек: ");
            int stepCount = Convert.ToInt32(Console.ReadLine());
            int minLength = 3;


            DrawStairs(stepCount, minLength);

            if (minLength < stepCount)
                minLength = stepCount;

            Console.WriteLine("\n");

            DrawExtendedStairs(stepCount, minLength);

        }

    }
}
