using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Multilingual.Areas.Dictionary.Pages;

[Authorize]
public class Index : PageModel
{
    public void OnGet()
    {
    }
}