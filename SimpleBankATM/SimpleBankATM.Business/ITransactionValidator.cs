using SimpleBankATM.Models;

namespace SimpleBankATM.Business
{
    public interface ITransactionValidator
    {
        TransactionStatus isValidTransaction();
    }
}