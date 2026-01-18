using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Backend.Infrastructure.Convertors;

public sealed class EnumMemberConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
        => typeToConvert.IsEnum;

    public override JsonConverter CreateConverter(Type type, JsonSerializerOptions options)
    {
        var converterType = typeof(EnumMemberConverter<>).MakeGenericType(type);
        return (JsonConverter)Activator.CreateInstance(converterType)!;
    }
    
    private sealed class EnumMemberConverter<T> : JsonConverter<T> where T : struct, Enum
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            
            if (value is null)
                throw new JsonException("Enum value is null");

            foreach (var field in typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var attr = field.GetCustomAttribute<EnumMemberAttribute>();
                
                if (attr?.Value == value || field.Name == value)
                    return (T)field.GetValue(null)!;
            }

            throw new JsonException($"Unknown enum value '{value}' for enum '{typeof(T).Name}'");
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            var field = typeof(T).GetField(value.ToString());
            var attr = field?.GetCustomAttribute<EnumMemberAttribute>();
            writer.WriteStringValue(attr?.Value ?? field!.Name);
        }
    }
}