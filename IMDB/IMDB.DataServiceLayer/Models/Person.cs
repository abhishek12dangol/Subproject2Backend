namespace IMDB.DataServiceLayer.Models;

public class Person
{
    public int PersonId { get; set; }
    public string Nconst { get; set; }
    public string PrimaryName { get; set; }
    public int? BirthYear { get; set; }
    public int? DeathYear { get; set; }
}