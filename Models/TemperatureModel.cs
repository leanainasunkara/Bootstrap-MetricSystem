using System.ComponentModel.DataAnnotations;

namespace MetricSystem.Models;

public class TemperatureModel
{
    [Display(Name = "Fahrenheit Value")]
    [Required(ErrorMessage = "FahrenheitValue is required.")]
    public double? FahrenheitValue { get; set; }

    [Display(Name = "Celsius Value")]
    public double? CelsiusValue { get; set; }
}
