﻿using System;
using Playnite.SDK.Models;

namespace Playnite
{
    public static class DateTimes
    {
        public interface IDateTimes
        {
            DateTime Now { get; }
            DateTime Today { get; }
        }

        public class DefaultDateProvider : IDateTimes
        {
            public DateTime Now => DateTime.Now;
            public DateTime Today => DateTime.Today;
        }

        public class TempDateTime : IDisposable
        {
            public TempDateTime(IDateTimes customDates)
            {
                dateProvider = customDates;
            }

            public void Dispose()
            {
                dateProvider = defaultDateProvider;
            }
        }

        private static IDateTimes defaultDateProvider = new DefaultDateProvider();
        private static IDateTimes dateProvider = defaultDateProvider;

        public static DateTime Now => dateProvider.Now;
        public static DateTime Today => dateProvider.Today;

        public static IDisposable UseCustomDates(IDateTimes dates)
        {
            return new TempDateTime(dates);
        }

        public static string ToDisplayString(this DateTime date, DateFormattingOptions options = null)
        {
            try
            {
                if (options == null)
                {
                    return date.ToString(Common.Constants.DateUiFormat);
                }

                if (options.PastWeekRelativeFormat)
                {
                    var today = Today;
                    var dayDiff = (today - date.Date).TotalDays;

                    if (dayDiff == 0)
                    {
                        return LOC.Today.GetLocalized();
                    }

                    if (dayDiff == 1)
                    {
                        return LOC.Yesterday.GetLocalized();
                    }

                    if (dayDiff > 1 && dayDiff < 7)
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Sunday:
                                return LOC.Sunday.GetLocalized();
                            case DayOfWeek.Monday:
                                return LOC.Monday.GetLocalized();
                            case DayOfWeek.Tuesday:
                                return LOC.Tuesday.GetLocalized();
                            case DayOfWeek.Wednesday:
                                return LOC.Wednesday.GetLocalized();
                            case DayOfWeek.Thursday:
                                return LOC.Thursday.GetLocalized();
                            case DayOfWeek.Friday:
                                return LOC.Friday.GetLocalized();
                            case DayOfWeek.Saturday:
                                return LOC.Saturday.GetLocalized();
                        }
                    }
                }

                return date.ToString(options.Format ?? Common.Constants.DateUiFormat);
            }
            catch (ArgumentOutOfRangeException)
            {
                // This is for rare cases where this fails on error similar to this:
                // Specified time is not supported in this calendar. It should be between 04/30/1900 00:00:00 (Gregorian date) and 11/16/2077 23:59:59 (Gregorian date), inclusive.
                // TODO: handle properly
                return "unsupported";
            }
        }

        public static string ToDisplayString(this ReleaseDate date, ReleaseDateFormattingOptions options = null)
        {
            if (date.Month == null && date.Day == null)
            {
                return date.Year.ToString();
            }

            if (date.Month != null && date.Day == null)
            {
                return date.Date.ToString(options.PartialFormat ?? Common.Constants.DefaultPartialReleaseDateTimeFormat);
            }

            return date.Date.ToDisplayString(options);
        }
    }
}
