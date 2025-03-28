using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PIApi.Models;
public class Contract
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public Car Car { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Price { get; set; }
}