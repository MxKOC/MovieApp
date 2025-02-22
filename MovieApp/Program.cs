using System.Text;
using BusinessLayer.Manager;
using BusinessLayer.Services;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Context;
using DataAccessLayer.Repository;
using DatabaseLayer.IdentityModels;
using DatabaseLayer.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieApp;
using MovieApp.Mapper;
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

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped(typeof(IGenericDal<Article>), typeof(GenericRepo<Article>));
builder.Services.AddScoped(typeof(IGenericDal<Genre>), typeof(GenericRepo<Genre>));
builder.Services.AddScoped(typeof(IGenericDal<Reader>), typeof(GenericRepo<Reader>));
builder.Services.AddScoped(typeof(IGenericDal<Writer>), typeof(GenericRepo<Writer>));
builder.Services.AddScoped(typeof(IGenericDal<Comment>), typeof(GenericRepo<Comment>));

builder.Services.AddScoped<IArticleDal, EFArticleRepo>();
builder.Services.AddScoped<IGenreDal, EFGenreRepo>();
builder.Services.AddScoped<IReaderDal, EFReaderRepo>();
builder.Services.AddScoped<IWriterDal, EFWriterRepo>();
builder.Services.AddScoped<ICommentDal, EFCommentRepo>();

builder.Services.AddScoped<IArticleServices, ArticleManager>();
builder.Services.AddScoped<IGenreServices, GenreManager>();
builder.Services.AddScoped<IReaderServices, ReaderManager>();
builder.Services.AddScoped<IWriterServices, WriterManager>();
builder.Services.AddScoped<ICommentServices, CommentManager>();

builder.Services.AddAutoMapper(typeof(CustomMapperProfile));



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option => option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
    });

    // JWT ayarlarını yapılandırma

    // Dependency Injection
    builder.Services.AddScoped<IJwtService, JwtManager>();



builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});




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
        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
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
