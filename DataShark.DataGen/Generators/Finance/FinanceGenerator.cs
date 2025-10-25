using Bogus;
using Bogus.Extensions.UnitedKingdom;
using DataShark.DataGen.Models;

namespace DataShark.DataGen.Generators.Finance;

public class FinanceGenerator(FinanceType financeType) : Generator
{
    public FinanceType FinanceType { get; set; } = financeType;
    public override Func<Faker, T, TPropType> Generate<T, TPropType>()
    {
        return FinanceType switch
        {
            FinanceType.Account => (f, _) => Convert<TPropType>(f.Finance.Account()),
            FinanceType.AccountName => (f, _) => Convert<TPropType>(f.Finance.AccountName()),
            FinanceType.Amount => (f, _) => Convert<TPropType>(f.Finance.Amount()),
            FinanceType.BankingSortCode => (f, _) => Convert<TPropType>(f.Finance.SortCode()),
            FinanceType.Bic => (f, _) => Convert<TPropType>(f.Finance.Bic()),
            FinanceType.BitcoinAddress => (f, _) => Convert<TPropType>(f.Finance.BitcoinAddress()),
            FinanceType.CreditCardCvv => (f, _) => Convert<TPropType>(f.Finance.CreditCardCvv()),
            FinanceType.CreditCardNumber => (f, _) => Convert<TPropType>(f.Finance.CreditCardNumber()),
            FinanceType.Currency => (f, _) => Convert<TPropType>(f.Finance.Currency()),
            FinanceType.EthereumAddress => (f, _) => Convert<TPropType>(f.Finance.EthereumAddress()),
            FinanceType.Iban => (f, _) => Convert<TPropType>(f.Finance.Iban()),
            FinanceType.LitecoinAddress => (f, _) => Convert<TPropType>(f.Finance.LitecoinAddress()),
            FinanceType.RoutingNumber => (f, _) => Convert<TPropType>(f.Finance.RoutingNumber()),
            FinanceType.TransactionType => (f, _) => Convert<TPropType>(f.Finance.TransactionType()),
            _ => throw new NotImplementedException(),
        };
    }
}
