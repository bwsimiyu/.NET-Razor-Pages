using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesRocket.Models;

public class Rocket
{
    public int Id { get; set; }
    [StringLength(256, MinimumLength = 4)]
    [Required]
    public string Name { get; set; } = string.Empty;
    [Display(Name = "Launch Date")]
    [DataType(DataType.Date)]
    public DateTime LaunchDate { get; set; }
    [Display(Name = "Number of Engines")]
    [Required]
    public string NumberOfEngines { get; set; } = string.Empty;
    [Column(TypeName = "decimal(18, 2)")]
    [Required]
    public string Payload { get; set; } = string.Empty;
    [Required]
    public string Cores { get; set; } = string.Empty;
    [Display(Name = "Desired Orbit")]
    [StringLength(3)]
    [Required]
    public string DesiredOrbit { get; set; } = string.Empty;
}