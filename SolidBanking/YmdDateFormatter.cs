namespace SolidBanking;

public sealed class YmdDateFormatter : IDateFormatter
{
    public string FormatDate(DateOnly date)
    {
        return date.ToString("yyyy-MM-dd");
    }
}