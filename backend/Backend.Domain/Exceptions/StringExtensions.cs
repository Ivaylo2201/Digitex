namespace Backend.Domain.Exceptions;

public static class StringExtensions
{
    public static string ToCapitalized(this string str)
        => string.IsNullOrEmpty(str) ? str : $"{char.ToUpper(str[0])}{str[1..]}";
}