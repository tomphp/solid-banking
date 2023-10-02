using SolidBanking.TransactionLog;

namespace SolidBanking.Statement;

public sealed class TabbedStatementPrinter : IStatementPrinter<IBalancedTransactionLine>
{
    private class TabbedStatementLinePrinter : IStatementLinePrinter<IBalancedTransactionLine>
    {
        public string PrintStatementLine(IBalancedTransactionLine line) =>
            $"\n{line.Date.ToString("yyyy-MM-dd")}\t{SignedAmount(line)}\t{line.Balance}";

        private static string SignedAmount(IBalancedTransactionLine line) =>
            line.Amount > 0 ? $"+{line.Amount}" : line.Amount.ToString();
    }

    public string PrintStatement(IEnumerable<IStatementLine<IBalancedTransactionLine>> transactions) =>
        transactions.Aggregate(
            "Date\tAmount\tBalance",
            (current, transaction) => current + transaction.PrintStatementLine(new TabbedStatementLinePrinter())
        );
}
