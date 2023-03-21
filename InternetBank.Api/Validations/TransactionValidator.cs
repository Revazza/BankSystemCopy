using CommonServices.Db.Entities;
using InternetBank.Models.Requests;

namespace InternetBank.API.Validations;

public class TransactionValidator
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionValidator(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }
    public void Validate(TranferRequest? request, UserEntity? user)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }
        if (request.Iban == null)
        {
            throw new ArgumentNullException(nameof(request.Iban));
        }
        if (request.SendFromIban == null)
        {
            throw new ArgumentNullException(nameof(request.SendFromIban));
        }
        if (request.Amount <= 0)
        {
            throw new InvalidOperationException("Amount must be greater than 0");
        }
        if (request.SendFromIban == request.Iban)
        {
            throw new InvalidOperationException("Can not transfer money to the same account,Iban must be different");
        }

        if (!_transactionRepository.IbanExists(request.Iban))
        {
            throw new Exception("Iban does not exist");
        }
        if (user == null)
        {
            throw new Exception("User not found;");
        }

    }
}