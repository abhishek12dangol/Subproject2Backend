using IMDB.DataServiceLayer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IPersonKnownFor, PersonKnownForService>();

var app = builder.Build();
app.MapControllers();
app.Run();

