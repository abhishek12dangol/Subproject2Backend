using IMDB.DataServiceLayer;

var service = new PersonKnownForService();
var query = service.GetPersonKnownFor(323407);
foreach (var person in query)
{
    Console.WriteLine(person);
}
