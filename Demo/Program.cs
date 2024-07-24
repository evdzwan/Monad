using Demo.Components;
using Monad;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

builder.Services.AddBinder()
                .AddThemes(defaultTheme: "dark");

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true)
       .UseHsts();
}

app.UseHttpsRedirection()
   .UseStaticFiles()
   .UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();
