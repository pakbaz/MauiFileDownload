var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/download", () =>
{
    var mimeType = "application/pdf";
    var path = Environment.CurrentDirectory + @"/certs.pdf";
    return Results.File(path, contentType: mimeType);
});

app.Run();

