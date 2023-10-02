namespace SolidBanking;

public sealed class TabbedStatementPrinter : IStatementPrinter
{
    private readonly IDateFormatter _dateFormatter;

    public TabbedStatementPrinter(IDateFormatter dateFormatter)
    {
        _dateFormatter = dateFormatter;
    }

    public string PrintStatement(List<(DateOnly, int)> transactions)
    {
        var statement = "Date\tAmount\tBalance";

        var balance = 0;
        foreach (var (date, amount) in transactions)
        {
            balance += amount;
            var transactionDate = _dateFormatter.FormatDate(date);
            statement += $"\n{transactionDate}\t+{amount}\t{balance}";
        }

        return statement;
    }
}