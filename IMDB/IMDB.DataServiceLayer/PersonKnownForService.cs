using IMDB.DataServiceLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace IMDB.DataServiceLayer;

public class PersonKnownForService: IPersonKnownFor
{
    private readonly ImdbContext _imdbContext;

    public PersonKnownForService()
    {
        _imdbContext = new ImdbContext();
    }
    public IEnumerable<PersonKnownFor> GetPersonKnownFor(int personId)
    {
        var query = _imdbContext.PersonKnownFors
            .Where(pk => pk.PersonId == personId)
            .Include(pk => pk.Movie)
            .ToList();
        return query;
    }
}