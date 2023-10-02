namespace SolidBanking;

public sealed class MockCurrentDateProvider : ICurrentDateProvider
{
    private DateOnly _date;

    public DateOnly CurrentDate() => _date;

    public void SetCurrentDate(DateOnly date) => _date = date;
}
