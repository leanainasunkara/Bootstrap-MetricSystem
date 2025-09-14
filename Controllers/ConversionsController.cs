using Microsoft.AspNetCore.Mvc;
using MetricSystem.Models;

namespace MetricSystem.Controllers;

public class ConversionsController : Controller
{
    [HttpGet]
    public IActionResult Fahrenheit() => View(new TemperatureModel());

    [HttpPost]
    public IActionResult Fahrenheit(TemperatureModel model, string? clear)
    {
        // Clear button: bypass validation and reset the form
        if (!string.IsNullOrEmpty(clear))
        {
            ModelState.Clear();
            return View(new TemperatureModel());
        }

        // If invalid, redisplay with errors (summary will show in red)
        if (!ModelState.IsValid)
            return View(model);

        // Compute F -> C
        double f = model.FahrenheitValue!.Value;
        double c = (f - 32.0) * 5.0 / 9.0;

        ModelState.Remove(nameof(TemperatureModel.CelsiusValue));
        model.CelsiusValue = c;

        return View(model);
    }
}
