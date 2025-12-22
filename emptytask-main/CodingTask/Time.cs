using System;

namespace CodingTask
{
    public class Time
    {
        private long seconds;

        public Time()
        {
            this.seconds = 0;
        }

        public Time(int h, int m, int s)
        {
            this.seconds = (h * 3600L) + (m * 60L) + s;
        }

        public Time(long totalSeconds)
        {
            this.seconds = totalSeconds;
        }

        public long Hours
        {
            get
            {
                return this.seconds / 3600;
            }
        }

        public long Minutes
        {
            get
            {
                return (this.seconds % 3600) / 60;
            }
        }

        public long Seconds
        {
            get
            {
                return this.seconds % 60;
            }
        }

        public long TotalSeconds
        {
            get
            {
                return this.seconds;
            }
        }

        public static Time operator +(Time t1, Time t2)
        {
            ArgumentNullException.ThrowIfNull(t1);
            ArgumentNullException.ThrowIfNull(t2);
            return t1.Add(t2);
        }

        public static Time operator -(Time t1, Time t2)
        {
            ArgumentNullException.ThrowIfNull(t1);
            ArgumentNullException.ThrowIfNull(t2);
            return t1.Subtract(t2);
        }

        public static Time Parse(string timeString)
        {
            if (string.IsNullOrWhiteSpace(timeString))
            {
                throw new ArgumentException("Рядок не може бути пустим");
            }

            string[] parts = timeString.Split(':');
            int h = 0, m = 0, s = 0;

            if (parts.Length >= 1)
            {
                _ = int.TryParse(parts[0], out h);
            }

            if (parts.Length >= 2)
            {
                _ = int.TryParse(parts[1], out m);
            }

            if (parts.Length >= 3)
            {
                _ = int.TryParse(parts[2], out s);
            }

            return new Time(h, m, s);
        }

        public Time Add(Time other)
        {
            ArgumentNullException.ThrowIfNull(other);
            return new Time(this.seconds + other.TotalSeconds);
        }

        public Time Subtract(Time other)
        {
            ArgumentNullException.ThrowIfNull(other);
            return new Time(this.seconds - other.TotalSeconds);
        }

        public override string ToString()
        {
            long h = this.Hours;
            long m = Math.Abs(this.Minutes);
            long s = Math.Abs(this.Seconds);

            return $"{h}:{m:D2}:{s:D2}";
        }
    }
}