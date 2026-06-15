using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace backend.models;

public enum ConversionLanguage
{
    ENGLISH,
    GERMAN,
}

public record ConversionResponse(string ConvertedNumber);

public class ConversionRequest
{
    [Range(0, 999_999_999.99, ErrorMessage = "Number must be between 0 and 999,999,999.99")]
    [JsonPropertyName("number")]
    public decimal Number { get; init; }

    [JsonPropertyName("language")]
    public ConversionLanguage Language { get; init; }
}
