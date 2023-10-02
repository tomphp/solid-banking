using SolidBanking.Statement;

namespace SolidBanking.TransactionLog;

public interface ITransactionLog<out TItem>
{
    void Add(Transaction transaction);

    string PrintStatement(IStatementPrinter<TItem> statementPrinter);
}
