var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.MapGet("/download", () =>
{
    var mimeType = "application/pdf";
    var path = Environment.CurrentDirectory + @"/certs.pdf";
    return Results.File(path, contentType: mimeType);
})
.WithName("download")
.WithOpenApi();

app.Run();

