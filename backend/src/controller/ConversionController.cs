using backend.lib;
using backend.models;
using Microsoft.AspNetCore.Mvc;

namespace backend.controller;

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
