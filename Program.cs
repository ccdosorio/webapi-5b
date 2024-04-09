using webapi_5b;
using webapi_5b.Filters;
using webapi_5b.Services;

var builder = WebApplication.CreateBuilder(args);

// Config port default with localhost
const int defaultPort = 5065;
var urls = new[] { $"http://localhost:{defaultPort}" };
builder.WebHost.UseUrls(urls);

// Add services to the container.

builder.Services.AddControllers(options =>
{
  options.Filters.Add(typeof(NotFoundExceptionFilterAttribute));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddNpgsql<AssignmentsContext>(builder.Configuration.GetConnectionString("5bDB"));

builder.Services.AddScoped<IAssignmentService, AssignmentService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();

// Enable CORS
app.UseCors(policy =>
{
  policy.AllowAnyOrigin();
  policy.AllowAnyMethod();
  policy.AllowAnyHeader();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
