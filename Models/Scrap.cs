using System.ComponentModel.DataAnnotations;

namespace scrap_depot.Models;

public class Scrap
{
    public int Id { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 2)] 
    public String Name { get; set; } = "";
    public String Description { get; set; } = "";
    [Required]
    [Range(0,999)]
    public int Credits { get; set; }
    [Range(0,999)]
    public int Weight { get; set; }
    public int Deposited { get; set; }

}