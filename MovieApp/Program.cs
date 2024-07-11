using DataAccessLayer.Context;
using DatabaseLayer.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieApp;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionStringArticle = builder.Configuration.GetConnectionString("ArticleConnection");
builder.Services.AddDbContext<ArticlesContext>(options =>
    options.UseSqlite(connectionStringArticle));



var connectionString = builder.Configuration.GetConnectionString("IdentityConnection");
builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddIdentity<User, IdentityRole>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();



using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var userManager = services.GetRequiredService<UserManager<User>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        SeedData.Initialize(services, userManager).Wait();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}



app.Run();
