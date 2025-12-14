using System;

namespace CodingTask
{
    public static class TaskClass
    {
        public static int Main()
        {
            Console.WriteLine(Resources.DemoTitle);
            Console.WriteLine(Resources.FirstTimePrompt);
            Time t1 = Time.ReadFromConsole();
            Console.WriteLine(Resources.SecondTimePrompt);
            Time t2 = Time.ReadFromConsole();
            Console.WriteLine($"Перший час: {t1}");
            Console.WriteLine($"Другий час: {t2}");
            Time sum = t1.Add(t2);
            Time diff = t1.Subtract(t2);
            Console.WriteLine($"Сума: {sum}");
            Console.WriteLine($"Різниця: {diff}");
            int t1Sec = t1.ToSeconds();
            int t2Sec = t2.ToSeconds();
            Console.WriteLine($"Перший час у секундах: {t1Sec}");
            Console.WriteLine($"Другий час у секундах: {t2Sec}");
            Console.WriteLine($"З секунд у час (перший): {Time.FromSeconds(t1Sec)}");
            Console.WriteLine($"З секунд у час (другий): {Time.FromSeconds(t2Sec)}");
            t1.WriteToFile("time1.txt");
            t2.WriteToFile("time2.txt");
            Console.WriteLine(Resources.TimeWrittenToFile);
            Time t1FromFile = Time.ReadFromFile("time1.txt");
            Console.WriteLine($"Зчитано з файлу: {t1FromFile}");
            Console.WriteLine(Resources.PressEnterToExit);
            _ = Console.ReadLine();
            return 0;
        }

        public static bool ChessMasterBishop(byte a, byte b, byte c, byte d)
        {
            throw new NotImplementedException();
        }

        public static bool ChessMasterCastle(byte a, byte b, byte c, byte d)
        {
            throw new NotImplementedException();
        }

        public static int CountDigitOccuresInNumber(int number, int digit)
        {
            throw new NotImplementedException();
        }

        public static int[][] JaggedArray(int n)
        {
            throw new NotImplementedException();
        }

        public static int[] SortArray(int[] inputArray)
        {
            throw new NotImplementedException();
        }
    }
}