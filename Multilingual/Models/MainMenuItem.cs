namespace Multilingual.Models;

public class MainMenuItem
{
    public string PathToImage { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string AspArea { get; set; }
    public string AspPage { get; set; }
    public string ButtonText { get; set; }

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