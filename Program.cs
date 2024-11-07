using Microsoft.EntityFrameworkCore;
using WebApplicationDemo.Data;
using WebApplicationDemo.DemoBL;
using WebApplicationDemo.DemoDAL;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<CertificateBL>();
builder.Services.AddScoped<CertificateDAL>(); 
builder.Services.AddScoped<UserDAL>();
builder.Services.AddScoped<UserBL>();

// Configure DbContext to use SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);




var app = builder.Build();


// Ensure database is created and seed data is available
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<ApplicationDbContext>();
    var logger = services.GetRequiredService<ILogger<Program>>();

    dbContext.Database.EnsureCreated();
    logger.LogInformation("Database created or already exists.");
    if (!dbContext.Users.Any())
    {
        logger.LogInformation("No users found in the database after creation.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
