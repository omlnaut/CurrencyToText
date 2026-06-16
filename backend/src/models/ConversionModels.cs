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
    /// <summary>
    /// Number to be converted. Must be between 0 and 999,999,999.99
    /// Only first two decimal digits are converted into cents, the rest is cut off.
    /// </summary>
    [Range(0, 999_999_999.99, ErrorMessage = "Number must be between 0 and 999,999,999.99")]
    [JsonPropertyName("number")]
    public decimal Number { get; init; }

    /// <summary>
    /// The language for the conversion. Regardless of language, currency will always be dollars/cents
    /// </summary>
    [JsonPropertyName("language")]
    public ConversionLanguage Language { get; init; }
}
