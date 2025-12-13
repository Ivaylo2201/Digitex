using Backend.Domain.Enums;

namespace Backend.Infrastructure.Extensions;

public static class StringExtensions
{
    public static CurrencyIsoCode ToCurrencyIsoCode(this string currency)
        => Enum.TryParse<CurrencyIsoCode>(currency, true, out var currencyIsoCode)
            ? currencyIsoCode
            : CurrencyIsoCode.Eur;
}