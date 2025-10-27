using IMDB.DataServiceLayer.Models;

namespace IMDB.DataServiceLayer;

public interface IPersonKnownFor
{
    IEnumerable<PersonKnownFor> GetPersonKnownFor(int personId);
}