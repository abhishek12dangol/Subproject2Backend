using IMDB.DataServiceLayer.Models;

namespace IMDB.DataServiceLayer;

public class PersonService: IPersonService
{
    private readonly ImdbContext _imdbContext;

    public PersonService()
    {
        _imdbContext = new ImdbContext();
    }
    public Person? GetPersonById(int id)
    {
        var query = _imdbContext.Persons.FirstOrDefault(p => p.PersonId == id);
        return query;
    }
}