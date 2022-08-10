using back.Repository;
using back.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);
AcessKey KeyConfig = new AcessKey();
var key = Encoding.UTF8.GetBytes(KeyConfig.Key);
// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("database");
builder.Services.AddCors();
builder.Services.AddSqlite<DatabaseContext>(connectionString);
builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer=false,
        ValidateAudience=false
    };

});

builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo{
        Title = "Cadastro API",
        Description = "Cadastro de clientes",
        Version = "v1"
    });
});

var app = builder.Build();
app.UseCors(p =>{
    p.WithOrigins("*")
    .AllowAnyMethod()
    .AllowAnyHeader();   
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json","Sistema API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
