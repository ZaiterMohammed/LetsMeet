using LetsMeet.Abstractions.Managers;
using LetsMeet.Abstractions.Store;
using LetsMeet.Business;
using LetsMeet.Store;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using LetsMeet.WebApi.Data;
using LetsMeet.WebApi.Areas.Identity.Data;
using LetsMeet.WebApi.Redis;
using LetsMeet.WebApi.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'LetsMeetWebApiContextConnection' not found.");

builder.Services.AddDbContext<LetsMeetWebApiContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<LetsMeetWebApiUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<LetsMeetWebApiContext>();

builder.Services.AddScoped<ICompanyManager, CompanyManager>();
builder.Services.AddScoped<ICompanyStore, CompanyStore>();

builder.Services.AddScoped<IOrganisationManager, OrganisationManager>();
builder.Services.AddScoped<IOrganisationStore, OrganisationStore>();

builder.Services.AddScoped<IPostManager, PostManager>();
builder.Services.AddScoped<IPostStore, PostStore>();

builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IUserStore, UserStore>();

builder.Services.AddScoped<IMunicipalityManager, MunicipalityManager>();
builder.Services.AddScoped<IMunicipalityStore, MunicipalityStore>();

builder.Services.AddScoped<IOfferManager, OfferManager>();
builder.Services.AddScoped<IOfferStore, OfferStore>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRabitMQProducer, RabitMQProducer>();

//var Key = Encoding.ASCII.GetBytes("MY_BIG_SECRET_KEY_LKSHDJFLSDKJFW@#($)(#)34234");
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            //todo
            var userMachine = context.HttpContext.RequestServices.GetRequiredService<UserManager<LetsMeetWebApiUser>>();
            var user = userMachine.GetUserAsync(context.HttpContext.User);
            if (user == null)
            {
                context.Fail("UnAuthorized");
            }
            return Task.CompletedTask;
        }
    };
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("MY_BIG_SECRET_KEY_LKSHDJFLSDKJFW@#($)(#)34234")),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});


builder.Services.AddSwaggerGen(setup =>
{
    // Include 'SecurityScheme' to use JWT Authentication
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });

});

builder.Services.AddControllers();
builder.Services.AddScoped<ICacheService, CacheService>();
builder.Services.AddDbContext<DbContextClass>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "RedisCacheDemo",
        Version = "v1"
    });
});



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
