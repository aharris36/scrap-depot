namespace scrap_depot.DTO;

public class ScrapDTO
{
    public int Id { get; set; }
    public String Name { get; set; } = "";
    public String Description { get; set; } = "";
    public int Credits { get; set; }
    public int Weight { get; set; }
    public int Deposited { get; set; }
    public Boolean TwoHanded { get; set; }
    public ICollection<ExpeditionDTO> Expeditions { get; set; } = new List<ExpeditionDTO>();
}