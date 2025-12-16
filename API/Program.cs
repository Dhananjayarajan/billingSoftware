using System.Text;
using Application.Bills.Commands;
using Application.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistance;
using Persistance.Interfaces;
using Persistance.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(x =>
		x.RegisterServicesFromAssemblyContaining<AssemblyReference>());



builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
		.AddJwtBearer(options =>
		{
			var tokenKey = builder.Configuration["TokenKey"]
					?? throw new Exception("Token key not found - program.cs");

			options.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
				ValidateIssuer = false,
				ValidateAudience = false
			};
		});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapGet("/", () => "Billing Software API is running");

app.MapControllers();

app.Run();
