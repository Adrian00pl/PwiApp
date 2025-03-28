using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PIApi.Models;

public class Model
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int MarkaId { get; set; }
    public Mark Mark { get; set; } = null!;
}