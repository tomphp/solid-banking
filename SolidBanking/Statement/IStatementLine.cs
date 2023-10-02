namespace SolidBanking.Statement;

public interface IStatementLine<out TItem>
{
    string PrintStatementLine(IStatementLinePrinter<TItem> statementLinePrinter);
}
