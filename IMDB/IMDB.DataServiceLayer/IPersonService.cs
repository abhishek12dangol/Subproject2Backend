using IMDB.DataServiceLayer.Models;

namespace IMDB.DataServiceLayer;

public interface IPersonService
{
    Person? GetPersonById(int id);
}