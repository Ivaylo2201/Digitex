using System.Runtime.Serialization;

namespace Backend.Domain.Enums;

public enum CurrencyIsoCode
{
     [EnumMember(Value = "EUR")]
     Eur,
     [EnumMember(Value = "USD")]
     Usd,
     [EnumMember(Value = "GBP")] 
     Gbp
}