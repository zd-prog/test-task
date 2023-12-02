namespace TestTask
{
    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt)
        {
            int diff = (7 + (dt.DayOfWeek - DayOfWeek.Monday)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        public static List<DateTime> CurrentWeek(this DateTime dt)
        {
            var week = new List<DateTime>();

            DateTime date = dt.StartOfWeek();
            week.Add(date);

            for (int i = 1; i < 7; i++)
            {
                date = date.AddDays(1);
                week.Add(date);
            }

            return week;
        }
    }
}

