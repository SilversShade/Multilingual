using Microsoft.AspNetCore.Mvc.RazorPages;

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
            new("/images/main-dictionary.jpg",
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

    public class MainMenuItem
    {
        public string PathToImage { get; }
        public string Title { get; }
        public string Description { get; }
        public string AspArea { get; }
        public string AspPage { get; }
        public string ButtonText { get; }

        public MainMenuItem(string pathToImage,
            string title,
            string description,
            string aspArea,
            string aspPage,
            string buttonText)
        {
            PathToImage = pathToImage;
            Title = title;
            Description = description;
            AspArea = aspArea;
            AspPage = aspPage;
            ButtonText = buttonText;
        }
    }
}