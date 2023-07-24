using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Multilingual.Models;

namespace Multilingual.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public readonly List<MainMenuItem> MainMenuItems;
    
    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        MainMenuItems = new List<MainMenuItem>
        {
            new ("/images/main-dictionary.jpg",
                "Dictionary",
                "Your own dictionary that supports many languages.",
                "Dictionary",
                "Index",
                "View dictionary")
        };
    }

    public void OnGet()
    {
        
    }
}