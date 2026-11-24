namespace scrap_depot.DTO;

public class ExpeditionDTO
{
    public int Id { get; set; }
    public int CrewNumber { get; set; } // frankly could make this into another class
    public String Moon { get; set; } = "";
    public String Notes { get; set; } = "";
    public DateTime ExpeditionDate;
}