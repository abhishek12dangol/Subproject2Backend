using IMDB.DataServiceLayer;

var service = new UserService();
var query = service.GetUserById(5);
