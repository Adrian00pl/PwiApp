using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PIApi.Models;
public class Mark
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
