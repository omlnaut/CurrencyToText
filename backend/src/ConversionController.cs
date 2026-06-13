using backend.lib;
using Microsoft.AspNetCore.Mvc;

namespace backend;

public record ConversionResponse(string ConvertedNumber);

[ApiController]
public class ConversionController : ControllerBase
{
    [HttpGet("Convert")]
    public ActionResult<ConversionResponse> Convert(decimal number)
    {
        var words = Converter.ToCurrency(number);
        return new ConversionResponse(words);
    }
}
