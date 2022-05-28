using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Muleki.Api.InputModels.Auth;
using Muleki.Api.InputModels.Football;
using Muleki.Api.InputModels.Player;
using Muleki.Api.InputModels.Safebox;
using Muleki.Domain.Entities;
using Muleki.Infra.Context;
using Muleki.Infra.Interfaces;
using Muleki.Infra.Repositories;
using Muleki.Service.Dto;
using Muleki.Service.Interfaces;
using Muleki.Service.Services;

var builder = WebApplication.CreateBuilder(args);
IConfiguration _configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();

#region JWT
byte[] keyEncode = Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]);
builder.Services.AddAuthentication(auth =>
    {
        auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(opt =>
    {
        opt.RequireHttpsMetadata = false;
        opt.SaveToken = true;
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(keyEncode),
            ValidateIssuer = true,
            ValidIssuer = _configuration["Jwt:Issuer"],
            ValidateAudience = true,
            ValidAudience = _configuration["Jwt:Audience"],
            ValidateLifetime = true,
        };
    });
#endregion

#region AutoMapper
MapperConfiguration cfgMapper = new MapperConfiguration(cfg =>
{
    // Player
    cfg.CreateMap<PlayerCreateInput, PlayerDto>();
    cfg.CreateMap<PlayerUpdateInput, PlayerDto>();
    cfg.CreateMap<PlayerDto, Player>().ReverseMap();
    
    // Authorization
    cfg.CreateMap<AuthInput, AuthDto>().ReverseMap();
    
    // Footaball
    cfg.CreateMap<FootballUpdateInput, FootballDto>();
    cfg.CreateMap<Football, FootballDto>().ReverseMap();

    // Score
    cfg.CreateMap<Score, ScoreDto>().ReverseMap();

    // Safebox
    cfg.CreateMap<SafeboxCreateInput, SafeboxDto>();
    cfg.CreateMap<SafeboxUpdateInput, PlayerDto>();
    cfg.CreateMap<Safebox, SafeboxDto>().ReverseMap();
});
#endregion

#region Injeção de Dependência (DI)
builder.Services.AddSingleton(_ => _configuration);
builder.Services.AddSingleton(cfgMapper.CreateMapper());
builder.Services.AddDbContext<MulekiContext>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
#endregion

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
