using web_api.AppDataContext;
using web_api.Interfaces;
using web_api.Middleware;
using web_api.Models;
using web_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add  This to in the Program.cs file
builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings")); // Add this line
builder.Services.AddSingleton<DatabaseContext>(); // Add this line
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());  // Add this line
builder.Services.AddExceptionHandler<GlobalExceptionHandler>(); // Add this line
builder.Services.AddProblemDetails();  // Add this line
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Adding of login 
builder.Services.AddLogging();  //  Add this line

builder.Services.AddScoped<ITodoServices, TodoServices>();

var app = builder.Build();
app.UseCors();

{
    using var scope = app.Services.CreateScope(); // Add this line
    var context = scope.ServiceProvider; // Add this line
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseExceptionHandler();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();
