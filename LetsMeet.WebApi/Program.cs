using LetsMeet.Abstractions.Managers;
using LetsMeet.Abstractions.Store;
using LetsMeet.Business;
using LetsMeet.Store;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICompanyManager, CompanyManager>();
builder.Services.AddScoped<ICompanyStore, CompanyStore>();

builder.Services.AddScoped<IOrganisationManager, OrganisationManager>();
builder.Services.AddScoped<IOrganisationStore, OrganisationStore>();

builder.Services.AddScoped<IPostManager, PostManager>();
builder.Services.AddScoped<IPostStore, PostStore>();

builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IUserStore, UserStore>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
