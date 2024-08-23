using Monad;
using Monad.Components;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddBinder()
                .AddRazorComponents()
                .AddInteractiveServerComponents();

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
