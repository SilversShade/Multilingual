using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Multilingual.Areas.Dictionary.Pages;

public class Index : PageModel
{
    public IActionResult OnGet()
    {
        if (User.Identity is {IsAuthenticated: true})
            return Page();
        return RedirectToPage("/Account/Login", new {area = "Identity"});
    }
}