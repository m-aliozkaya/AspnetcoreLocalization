using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MvcExample.Models;

public class LoginModel
{
    [Display(Name = "Email")]
    [Required(ErrorMessage = "{0} is required")]
    [BindProperty]
    public string Email { get; set; }
    
    [Display(Name = "Password")]
    [Required(ErrorMessage = "{0} is required")]
    [BindProperty]
    public string Password { get; set; }
}