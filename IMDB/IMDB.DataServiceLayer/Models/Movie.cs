namespace IMDB.DataServiceLayer.Models;

public class Movie
{
    public int Id { get; set; }
    public string Tconst { get; set; }
    public string TitleType { get; set; }
    public string PrimaryTitle { get; set; }
    public string? OriginalTitle { get; set; }
    public bool IsAdult { get; set; }
    public int? StartYear { get; set; }
    public int? EndYear { get; set; }
    public int? RunTimeMinutes { get; set; }
    public string? PlotSummary { get; set; }
    public string? PosterUrl { get; set; }
    public IList<PersonKnownFor> KnownFors { get; set; }
}