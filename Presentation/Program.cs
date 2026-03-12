using Presentation;
using Presentation.Components;
using Presentation.Habs;
using Presentation.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

builder.Configuration.AddJsonFile("s3settings.json", optional: false, reloadOnChange: true);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.InjectServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddBlazorBootstrap();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapHub<NomenclatureUpdateHub>("/nomenclature-hub");

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
