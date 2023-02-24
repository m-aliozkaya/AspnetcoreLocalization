using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace RazorPagesExample.Pages;

public class IndexModel : PageModel
{
    [Display(Name = "Email")]
    [Required(ErrorMessage = "{0} is required")]
    [BindProperty]
    public string Email { get; set; }
    
    [Display(Name = "Password")]
    [Required(ErrorMessage = "{0} is required")]
    [BindProperty]
    public string Password { get; set; }
    
    private readonly IStringLocalizer<IndexModel> _localizer;

    public IndexModel(IStringLocalizer<IndexModel> localizer)
    {
        _localizer = localizer;
    }

    public void OnGet()
    {
        var message = _localizer["Message"];
        ViewData["Message"] = message;
    }
}