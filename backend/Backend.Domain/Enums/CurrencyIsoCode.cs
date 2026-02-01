using System.Text.Json.Serialization;

namespace Backend.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CurrencyIsoCode
{
     [JsonStringEnumMemberName("EUR")]
     Eur,
     
     [JsonStringEnumMemberName("USD")]
     Usd,
     
     [JsonStringEnumMemberName("GBP")]
     Gbp
}