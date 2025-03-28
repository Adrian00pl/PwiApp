using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PiProject.Models;
public class Mark
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
