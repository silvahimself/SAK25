namespace SAK25.Extensions;

public static class DateTimeExtensions
{
    private static DateTime yearZero = new DateTime(1, 1, 1);

    /// <summary>
    /// Calculates and returns the years elapsed since a certain date.
    /// </summary>
    /// <param name="date"></param>
    /// <returns>The years elapsed from a date to right now. </returns>
    public static int YearsElapsed(this DateTime date)
    {
        return (yearZero + (DateTime.UtcNow - date)).Year - 1;
    }
}
