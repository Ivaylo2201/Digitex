using Backend.Domain.Enums;

namespace Backend.Domain.Extensions;

public static class StringExtensions
{
    extension(string currency)
    {
        public CurrencyIsoCode ToCurrencyIsoCode()
            => Enum.TryParse<CurrencyIsoCode>(currency, true, out var currencyIsoCode)
                ? currencyIsoCode
                : CurrencyIsoCode.Eur;

        public string ToCapitalized()
            => string.IsNullOrEmpty(currency) ? currency : $"{char.ToUpper(currency[0])}{currency[1..]}";
    }
}