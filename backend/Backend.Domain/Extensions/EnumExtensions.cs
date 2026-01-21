using System.Reflection;
using System.Text.Json.Serialization;

namespace Backend.Domain.Extensions;

public static class EnumExtensions
{
    public static string GetEnumMemberValue<T>(this T enumValue) where T : Enum
    {
        var member = typeof(T).GetMember(enumValue.ToString()).FirstOrDefault();
        var attr = member?.GetCustomAttribute<JsonStringEnumMemberNameAttribute>();
        return attr?.Name ?? enumValue.ToString();
    }
}