using System.ComponentModel.DataAnnotations;
using scrap_depot.Models;

namespace scrap_depot.ViewModels;

// What the registration form posts. It is not the Member: the password
// arrives here once, gets hashed by Identity, and is never stored.
public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";

    [Required]
    [Display(Name = "Crew Number")]
    public int CrewNumber { get; set; }

    [Required]
    [Display(Name = "First Name")]
    public string FirstName { get; set; } = "";

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = "";

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare(nameof(Password), ErrorMessage = "The two passwords don't match.")]
    public string ConfirmPassword { get; set; } = "";
}