using Store.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// ProgramExtensions.cs
builder.ConfigureServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
