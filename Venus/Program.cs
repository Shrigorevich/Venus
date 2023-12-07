using AutoMapper;
using Venus.Authorization;
using Venus.Database;
using Venus.Database.Contracts;
using Venus.Domain;
using Venus.Domain.Mapping;

var builder = WebApplication.CreateBuilder(args);

const string origins = "customAllowedOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: origins,
        policy  =>
        {
            policy.WithOrigins(
                "http://127.0.0.1:3000"
            ).AllowCredentials();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IChallengeService, ChallengeService>();
builder.Services.AddSingleton<IChallengeDayService, ChallengeDayService>();
builder.Services.AddSingleton<IPurchaseService, PurchaseService>();


builder.Services.AddAutoMapper(
    typeof(ChallengeProfile)
);

builder.Services.AddSingleton<KratosService>();
builder.Services
    .AddAuthentication("Kratos")
    .AddScheme<KratosAuthenticationOptions, KratosAuthHandler>("Kratos", null);

builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IChallengeService, ChallengeService>();
builder.Services.AddSingleton<IChallengeRepo, ChallengeRepo>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(origins);
app.UseAuthorization();
app.MapControllers();

app.Run();