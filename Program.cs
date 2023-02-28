var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

var app = builder.Build();



app.UseMvc(routes =>
{
    //routes.MapRoute("secure", "secure", new
    //{
    //    Controller = "Admin",
    //    Action = "Index"
    //});

    //routes.MapRoute("default", "{controller=Home}/{action=Index}/{id:alpha:minlength(6)?}");
    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
});
app.MapGet("/", () => "Hello World!");

app.Run();
