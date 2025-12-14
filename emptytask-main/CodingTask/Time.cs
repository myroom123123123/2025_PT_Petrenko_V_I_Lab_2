using System;
using System.Globalization;
using System.IO;

namespace CodingTask
{
    public struct Time : IEquatable<Time>
    {
        public static Time FromSeconds(int totalSeconds)
        {
            int sign = Math.Sign(totalSeconds);
            totalSeconds = Math.Abs(totalSeconds);
            int h = totalSeconds / 3600;
            int m = (totalSeconds % 3600) / 60;
            int s = totalSeconds % 60;
            return new Time(sign * h, sign * m, sign * s);
        }

        public static Time Parse(string input)
        {
            ArgumentNullException.ThrowIfNull(input);
            input = input.Trim();
            bool negative = input.StartsWith('-');
            if (negative)
            {
                input = input[1..];
            }
            string[] parts = input.Split(':');
            if (parts.Length != 3)
            {
                throw new FormatException("Invalid time format");
            }
            int h = int.Parse(parts[0], CultureInfo.InvariantCulture);
            int m = int.Parse(parts[1], CultureInfo.InvariantCulture);
            int s = int.Parse(parts[2], CultureInfo.InvariantCulture);
            if (negative)
            {
                h = -h;
                m = -m;
                s = -s;
            }
            return new Time(h, m, s);
        }

        public static Time ReadFromConsole()
        {
            Console.Write(Resources.EnterTimePrompt);
            string input = Console.ReadLine();
            return Parse(input);
        }

        public static Time ReadFromFile(string path)
        {
            string input = File.ReadAllText(path).Trim();
            return Parse(input);
        }

        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public Time(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
            Normalize();
        }

        public int ToSeconds()
        {
            return (Hours * 3600) + (Minutes * 60) + Seconds;
        }

        public Time Add(Time other)
        {
            return this + other;
        }

        public Time Subtract(Time other)
        {
            return this - other;
        }

        public void WriteToConsole()
        {
            Console.WriteLine(ToString());
        }

        public void WriteToFile(string path)
        {
            File.WriteAllText(path, ToString());
        }

        private void Normalize()
        {
            int total = ToSeconds();
            int sign = Math.Sign(total);
            total = Math.Abs(total);
            Hours = sign * (total / 3600);
            Minutes = sign * ((total % 3600) / 60);
            Seconds = sign * (total % 60);
        }

        public static Time operator +(Time t1, Time t2)
        {
            return FromSeconds(t1.ToSeconds() + t2.ToSeconds());
        }

        public static Time operator -(Time t1, Time t2)
        {
            return FromSeconds(t1.ToSeconds() - t2.ToSeconds());
        }

        public static bool operator ==(Time left, Time right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Time left, Time right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            return obj is Time time && Equals(time);
        }

        public bool Equals(Time other)
        {
            return ToSeconds() == other.ToSeconds();
        }

        public override int GetHashCode()
        {
            return ToSeconds().GetHashCode();
        }

        public override string ToString()
        {
            string sign = ToSeconds() < 0 ? "-" : string.Empty;
            int absH = Math.Abs(Hours);
            int absM = Math.Abs(Minutes);
            int absS = Math.Abs(Seconds);
            return $"{sign}{absH:D2}:{absM:D2}:{absS:D2}";
        }
    }

    public static class Resources
    {
        public static readonly string EnterTimePrompt = "Enter time (HH:MM:SS): ";
        public static readonly string DemoTitle = "Демонстрація класу Time:";
        public static readonly string FirstTimePrompt = "Введіть перший час (HH:MM:SS):";
        public static readonly string SecondTimePrompt = "Введіть другий час (HH:MM:SS):";
        public static readonly string TimeWrittenToFile = "Час записано у файли time1.txt та time2.txt";
        public static readonly string PressEnterToExit = "Натисніть Enter для завершення...";
    }
}
