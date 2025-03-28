using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PIApi.Models;
public class CarDto
{
    public string LicensePlate { get; set; } = string.Empty;
    public int ModelId { get; set; }
    public int Year { get; set; }
}