using Microsoft.AspNetCore.Mvc.Rendering;
using scrap_depot.Models;

namespace scrap_depot.ViewModels;

public class ExpeditionFormViewModel
{
    public Expedition Expedition { get; set; } = new();
    public List<int> SelectedScrapIds { get; set; } = new();
    public SelectList? ScrapChoices { get; set; }
}