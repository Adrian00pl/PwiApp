using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PIApi.Models;
public class Car
{
    public int Id { get; set; }
    public string LicensePlate { get; set; } = string.Empty;
    public int ModelId { get; set; }
    public Model Model { get; set; } = null!;
    public int Year { get; set; }
}