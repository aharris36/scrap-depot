using Microsoft.AspNetCore.Identity;

namespace scrap_depot.Models;

// A member of the Registry. Everything Identity needs — the email, the
// password hash, the lockout counters — comes from IdentityUser. This class
// is where the Registry's own facts about a member will go.
public class EmployeeUser : IdentityUser
{
    public int CrewNumber { get; set; }
    
    public string FirstName { get; set; } = "";
}