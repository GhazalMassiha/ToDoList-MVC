using System.Globalization;

namespace ToDoList.Framework
{
    public static class PersianDateParseExtensions
    {
        /// <summary>
        /// Parses a Persian (Jalali) date string such as "1404/08/31" or "1404/08/31 15:30"
        /// into a Gregorian DateTime. Returns null if parsing fails.
        /// </summary>
        public static DateTime? ParsePersianDate(this string persianDateString)
        {
            if (string.IsNullOrWhiteSpace(persianDateString))
                return null;

            // Normalize Persian digits to Latin digits
            var digitsMap = new[]
            {
                new { Persian = '۰', Latin = '0' },
                new { Persian = '۱', Latin = '1' },
                new { Persian = '۲', Latin = '2' },
                new { Persian = '۳', Latin = '3' },
                new { Persian = '۴', Latin = '4' },
                new { Persian = '۵', Latin = '5' },
                new { Persian = '۶', Latin = '6' },
                new { Persian = '۷', Latin = '7' },
                new { Persian = '۸', Latin = '8' },
                new { Persian = '۹', Latin = '9' },
            };

            string normalized = persianDateString;
            foreach (var map in digitsMap)
            {
                normalized = normalized.Replace(map.Persian, map.Latin);
            }

            // Split date and optional time
            var parts = normalized.Split(' ');
            string datePart = parts[0];
            string timePart = parts.Length > 1 ? parts[1] : "00:00";

            string[] dateParts = datePart.Split('/');
            if (dateParts.Length != 3)
                return null;

            if (!int.TryParse(dateParts[0], out int pYear)) return null;
            if (!int.TryParse(dateParts[1], out int pMonth)) return null;
            if (!int.TryParse(dateParts[2], out int pDay)) return null;

            int hour = 0, minute = 0;
            var timeParts = timePart.Split(':');
            if (timeParts.Length >= 1) int.TryParse(timeParts[0], out hour);
            if (timeParts.Length >= 2) int.TryParse(timeParts[1], out minute);

            try
            {
                PersianCalendar pc = new PersianCalendar();
                DateTime dt = pc.ToDateTime(pYear, pMonth, pDay, hour, minute, 0, 0);
                return dt;
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
        }
    }
}
