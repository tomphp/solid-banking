using SolidBanking.TransactionLog;

namespace SolidBanking.Statement;

public sealed class TabbedStatementPrinter : IStatementPrinter<IBalancedTransactionLine>
{
    private class TabbedStatementLinePrinter : IStatementLinePrinter<IBalancedTransactionLine>
    {
        public string PrintStatementLine(IBalancedTransactionLine line)
        {
            var amount = line.Amount > 0 ? $"+{line.Amount}" : line.Amount.ToString();
            return $"\n{line.Date.ToString("yyyy-MM-dd")}\t{amount}\t{line.Balance}";
        }
    }

    public string PrintStatement(IEnumerable<IStatementLine<IBalancedTransactionLine>> transactions) =>
        transactions.Aggregate(
            "Date\tAmount\tBalance",
            (current, transaction) => current + transaction.PrintStatementLine(new TabbedStatementLinePrinter())
        );
}
