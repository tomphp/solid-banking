namespace SolidBanking;

public sealed class MockCurrentDateProvider : ICurrentDateProvider
{
    private DateOnly _date;

    public DateOnly CurrentDate()
    {
        return _date;
    }

    public void SetCurrentDate(DateOnly date)
    {
        _date = date;
    }
}