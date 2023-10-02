namespace SolidBanking.Statement;

public interface IStatement<out TItem>
{
    string PrintStatement(IStatementPrinter<TItem> statementPrinter);
}
