using System.Globalization;

namespace Venus.Common.Extentions;

public static class DateTimeExtension
{

    public static string PeriodStart(this DateTime date, CultureInfo ci, BudgetPeriod p)
    {
        switch (p)
        {
            case BudgetPeriod.Week:
                return date.StartOfWeek(ci);
            case BudgetPeriod.Month:
                return date.StartOfMonth();
            case BudgetPeriod.Quarter:
                return date.StartOfQuarter();
            case BudgetPeriod.Year:
                return date.StartOfYear();
            default:
                throw new Exception("Wrong period type: " + (int)p);
        }
    }
    
    public static string PeriodEnd(this DateTime date, CultureInfo ci, BudgetPeriod p)
    {
        switch (p)
        {
            case BudgetPeriod.Week:
                return date.EndOfWeek(ci);
            case BudgetPeriod.Month:
                return date.EndOfMonth();
            case BudgetPeriod.Quarter:
                return date.EndOfQuarter();
            case BudgetPeriod.Year:
                return date.EndOfYear();
            default:
                throw new Exception("Wrong period type: " + (int)p);
        }
    }

    private static string StartOfMonth(this DateTime date)
    {
        var start = date.AddDays(-date.Day+1);
        return DateOnly.FromDateTime(start).ToString("o");
    } 
    
    private static string EndOfMonth(this DateTime date)
    {
        var end = date.AddDays(DateTime.DaysInMonth(date.Year, date.Month) - date.Day);
        return DateOnly.FromDateTime(end).ToString("o");
    } 
    
    private static string StartOfQuarter(this DateTime date)
    {
        var currQuarter = (date.Month - 1) / 3 + 1;
        var qStart = new DateTime(date.Year, 3 * currQuarter - 2, 1);
        return DateOnly.FromDateTime(qStart).ToString("o");
    } 
    
    private static string EndOfQuarter(this DateTime date)
    {
        var currQuarter = (date.Month - 1) / 3 + 1;
        var qLast = new DateTime(date.Year, 3 * currQuarter, 1).AddMonths(1).AddDays(-1);
        return DateOnly.FromDateTime(qLast).ToString("o");
    } 
    
    private static string StartOfYear(this DateTime date)
    {
        var yearStart = new DateTime(date.Year, 1, 1);
        return DateOnly.FromDateTime(yearStart).ToString("o");
    } 
    
    private static string EndOfYear(this DateTime date)
    {
        var yearStart = new DateTime(date.Year, 12, DateTime.DaysInMonth(date.Year, 12));
        return DateOnly.FromDateTime(yearStart).ToString("o");
    } 
    
    private static string StartOfWeek(this DateTime date, CultureInfo ci)
    {
        var start = ci.DateTimeFormat.FirstDayOfWeek;
        var today = date.DayOfWeek;
        return DateOnly.FromDateTime(DateTime.Now.AddDays(-(today - start))).ToString("o");
    }
    
    private static string EndOfWeek(this DateTime date, CultureInfo ci)
    {
        var start = ci.DateTimeFormat.FirstDayOfWeek;
        var today = date.DayOfWeek;
        return DateOnly.FromDateTime(DateTime.Now.AddDays(-(today - start) + 6)).ToString("o");
    }
}
