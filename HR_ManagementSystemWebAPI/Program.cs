using HR_ManagementSystemWebAPI;
using HR_ManagementSystemWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using System;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;


var builder = WebApplication.CreateBuilder(args);
var blacklistedTokens = new HashSet<string>();

static bool IsOriginAllowed(string origin)
{
    Uri uri = new(origin);
    bool isAllowed = uri.Host.Equals("localhost", StringComparison.OrdinalIgnoreCase);
    return isAllowed;
}

builder.Services.AddSingleton<HashSet<string>>(blacklistedTokens);


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptions => sqlServerOptions.CommandTimeout(1000)));

builder.Services.AddDbContext<HRDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services
                .AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false).
                AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

// Get JWT settings from appsettings.json
var jwtSettings = builder.Configuration.GetSection("JwtSettings");

var key = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]);


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var jwtSettings = builder.Configuration.GetSection("JwtSettings");
    var key = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]);

    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidateAudience = true,
        ValidAudience = jwtSettings["Audience"],
        ValidateLifetime = true,
        ClockSkew = TimeSpan.FromMinutes(3)
    };

    // Inject blacklisted tokens for token validation
    options.Events = new JwtBearerEvents
    {
        OnTokenValidated = async context =>
        {
            var blacklistedTokens = context.HttpContext.RequestServices.GetRequiredService<HashSet<string>>();
            var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            // Check if token is blacklisted
            if (blacklistedTokens.Contains(token))
            {
                context.Fail("This token has been invalidated. Please log in again.");
            }
        },
        OnChallenge = async context =>
        {
            if (!context.Response.HasStarted)
            {
                context.HandleResponse();
                context.Response.StatusCode = 401;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync("{\"error\": \"Unauthorized\", \"message\": \"The token has expired or is invalid.\"}");
            }
        }
    };
});



// Enable Cors
_ = builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowedCorsOrigins",
        builder =>
        {
            _ = builder
                .SetIsOriginAllowed(IsOriginAllowed)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    // Map Scalar UI
    app.MapScalarApiReference("/docs/scalar");
}

app.UseHttpsRedirection();

app.UseCors("AllowedCorsOrigins");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();