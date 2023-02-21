using Microsoft.Extensions.DependencyInjection;
using Application.Services;
using Application.Services.Contracts;
using Application.Services.Implementation;
using Distrubuted.WebAPI.Profiles;
using Application.Services.Profiles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using System.Net;
using Microsoft.AspNetCore.Mvc.Versioning;
using CrossCutting.Utils;
using Application.Services.Config;
using Infrastucture.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseKestrel(options => options.AddServerHeader = false);
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddControllers();
builder.Services.ConfigServices(builder.Configuration);
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IOutputGroundHandlingService, OutputGroundHandlingService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(ApiProfile));
builder.Services.AddAutoMapper(typeof(ServiceProfile));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Economanager", Version = "V1" });
    options.AddSecurityDefinition("JWT", new OpenApiSecurityScheme
    {
        Description = "",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "JWT",
                }
            },
            new List<string>()
        }
    });
});

builder.Services
    .AddHttpContextAccessor()
    .AddAuthorization()
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddApiVersioning(o =>
{
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    o.ReportApiVersions = true;
    o.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Version"),
        new MediaTypeApiVersionReader("ver"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

await UserDBInitialize.SeedRoles(app);
await UserDBInitialize.SeedUsers(app);

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
