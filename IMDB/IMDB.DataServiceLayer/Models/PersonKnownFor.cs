namespace IMDB.DataServiceLayer.Models;

public class PersonKnownFor
{
    public int PersonId { get; set; }
    public int MovieId { get; set; }
    public Person Person { get; set; }
    public Movie Movie { get; set; }
}