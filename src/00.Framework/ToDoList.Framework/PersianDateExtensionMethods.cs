using System.Globalization;
using System.Reflection;

namespace ToDoList.Framework
{
    public static class PersianDateExtensionMethods
    {
        private static CultureInfo? _culture;
        public static CultureInfo GetPersianCulture()
        {
            if (_culture == null)
            {
                _culture = new CultureInfo("fa-IR");
                DateTimeFormatInfo formatInfo = _culture.DateTimeFormat;
                formatInfo.AbbreviatedDayNames = new[] { "ی", "د", "س", "چ", "پ", "ج", "ش" };
                formatInfo.DayNames = new[] { "یکشنبه", "دوشنبه", "سه‌شنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه" };
                var monthNames = new[]
                {
                    "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور",
                    "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", ""
                };
                formatInfo.MonthNames = monthNames;
                formatInfo.AbbreviatedMonthNames = monthNames;
                formatInfo.MonthGenitiveNames = monthNames;
                formatInfo.AbbreviatedMonthGenitiveNames = monthNames;
                formatInfo.AMDesignator = "ق.ظ";
                formatInfo.PMDesignator = "ب.ظ";
                formatInfo.ShortDatePattern = "yyyy/MM/dd";
                formatInfo.LongDatePattern = "dddd, dd MMMM yyyy";
                formatInfo.FirstDayOfWeek = DayOfWeek.Saturday;

                PersianCalendar persianCalendar = new PersianCalendar();

                FieldInfo? fieldInfo = typeof(CultureInfo).GetField("calendar", BindingFlags.NonPublic | BindingFlags.Instance);
                if (fieldInfo != null)
                    fieldInfo.SetValue(_culture, persianCalendar);

                FieldInfo? info = typeof(DateTimeFormatInfo).GetField("calendar", BindingFlags.NonPublic | BindingFlags.Instance);
                if (info != null)
                    info.SetValue(formatInfo, persianCalendar);
            }
            return _culture;
        }

        public static string ToPersianString(this DateTime date, string format = "yyyy/MM/dd")
        {
            try
            {
                return date.ToString(format, GetPersianCulture());
            }
            catch (ArgumentOutOfRangeException)
            {
                // fallback if date is outside PersianCalendar range
                return date.ToString(format, CultureInfo.InvariantCulture);
            }
        }
    }
}