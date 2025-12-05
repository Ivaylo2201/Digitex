using System.Reflection;
using System.Runtime.Serialization;

namespace Backend.Domain.Extensions;

public static class EnumExtensions
{
    public static string GetEnumMemberValue<T>(this T enumValue) where T : Enum
    {
        var member = typeof(T).GetMember(enumValue.ToString()).FirstOrDefault();
        var attr = member?.GetCustomAttribute<EnumMemberAttribute>();
        return attr?.Value ?? enumValue.ToString();
    }
}