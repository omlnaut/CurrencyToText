using backend.lib;
using Microsoft.AspNetCore.Mvc;

namespace backend;

public enum ConversionLanguage
{
    ENGLISH,
    GERMAN,
}

public record ConversionResponse(string ConvertedNumber);

[ApiController]
public class ConversionController : ControllerBase
{
    [HttpGet("Convert")]
    public ActionResult<ConversionResponse> Convert(decimal number, ConversionLanguage language)
    {
        var words = language switch
        {
            ConversionLanguage.ENGLISH => EnglishConverter.ToCurrency(number),
            ConversionLanguage.GERMAN => GermanConverter.ToCurrency(number),
            _ => throw new NotImplementedException(),
        };

        return new ConversionResponse(words);
    }
}
