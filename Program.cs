using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(
               options =>
               {
                   options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                   options.SerializerSettings.TypeNameHandling = TypeNameHandling.None;
                   options.SerializerSettings.Formatting = Formatting.Indented;
               }
               )
               .AddXmlSerializerFormatters()
               .AddJsonOptions(options => {
                   options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                   options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
               })
               .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver()
            );
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseFileServer(new FileServerOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"data")),
    RequestPath = new Microsoft.AspNetCore.Http.PathString(@"/data"),
    EnableDirectoryBrowsing = true
});
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
