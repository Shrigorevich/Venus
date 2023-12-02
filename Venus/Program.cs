using Venus.Authorization;
using Venus.Database;
using Venus.Database.Contracts;
using Venus.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton(new KratosService());   
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

app.UseAuthorization();

app.MapControllers();

app.Run();