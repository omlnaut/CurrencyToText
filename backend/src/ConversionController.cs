using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using backend.lib;
using Microsoft.AspNetCore.Mvc;

namespace backend;

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

[ApiController]
public class ConversionController : ControllerBase
{
    [HttpGet("Convert")]
    public ActionResult<ConversionResponse> Convert([FromQuery] ConversionRequest request)
    {
        var words = request.Language switch
        {
            ConversionLanguage.ENGLISH => EnglishConverter.ToCurrency(request.Number),
            ConversionLanguage.GERMAN => GermanConverter.ToCurrency(request.Number),
            _ => throw new NotImplementedException(),
        };

        return new ConversionResponse(words);
    }
}
