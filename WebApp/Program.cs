using WebApp.Handlers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("AzureBlobStorage");
var containerName = "images";
builder.Services.AddScoped<IFileHandler>(_ => new AzureFileHandler(connectionString!, containerName));

var app = builder.Build();

app.MapOpenApi();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors("AllowAll");

app.Run();
