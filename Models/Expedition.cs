using System.ComponentModel.DataAnnotations;

namespace scrap_depot.Models;

public class Expedition
{
    public int Id { get; set; }
    public int CrewNumber { get; set; } // frankly could make this into another class

    [Required(ErrorMessage = "Which moon did the expedition go to?")]
    [StringLength(30, MinimumLength = 3)]
    public String Moon { get; set; } = "";
    [StringLength(500)]
    public String Notes { get; set; } = "";

    [DataType(DataType.Date)]
    public DateTime ExpeditionDate;
    

    [Display(Name = "Scrap Collected")]
    public List<int> ScrapIds { get; set; } = new List<int>();
    public ICollection<Scrap> ScrapCollected { get; set; } = new List<Scrap>();

}