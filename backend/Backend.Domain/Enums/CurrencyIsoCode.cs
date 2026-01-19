using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Backend.Domain.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum CurrencyIsoCode
{
     [EnumMember(Value = "EUR")]
     Eur,
     [EnumMember(Value = "USD")]
     Usd,
     [EnumMember(Value = "GBP")] 
     Gbp
}