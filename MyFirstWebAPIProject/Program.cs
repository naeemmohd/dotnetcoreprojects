using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using MyFirstWebAPIProject.Controllers;
using MyFirstWebAPIProject.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
	c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
	c.IgnoreObsoleteActions();
	c.IgnoreObsoleteProperties();
	c.CustomSchemaIds(type => type.FullName);
});

//add EF DB Context
builder.Services.AddDbContext<EFCoreDbContext>(opt => {
	opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStandardRepository, StandardRepository>();

builder.Services.AddTransient<MyCustomMiddleware>();

// add CORS policy 
builder.Services.AddCors(opt =>
{
	opt.AddPolicy("CorsPolicy", policy => 
	{
		policy.AllowAnyHeader().AllowAnyMethod();
	});
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//use CORS policy
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

//app.UseMiddleware<MyCustomMiddleware>();
// automate EF DB creation
/*using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<EFCoreDbContext>();
var logger = services.GetRequiredService<ILogger<Program>>();
try
{
    await context.Database.MigrateAsync();
    //await StoreContextSeed.SeedAsync(context);
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred during migration");
}
*/

//testing EF save
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<EFCoreDbContext>();

//For seeding data //commented to manually enter data for time being
//EFCoreDbContextSeed.Seed(context);

app.Run();
