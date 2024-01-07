using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using proiectChioranAndrei.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Orase/");
    options.Conventions.AuthorizeFolder("/ObiectiveTuristice/");
    options.Conventions.AuthorizeFolder("/Tari/");
    options.Conventions.AllowAnonymousToPage("/Orase/Index");
    options.Conventions.AllowAnonymousToPage("/Tari/Index");
    options.Conventions.AllowAnonymousToPage("/ObiectiveTuristice/Index");
    options.Conventions.AllowAnonymousToPage("/Orase/Details");
    options.Conventions.AllowAnonymousToPage("/Tari/Details");
    options.Conventions.AllowAnonymousToPage("/ObiectiveTuristice/Details");

});
builder.Services.AddDbContext<proiectChioranAndreiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("proiectChioranAndreiContext") ?? throw new InvalidOperationException("Connection string 'proiectChioranAndreiContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("proiectChioranAndreiContext") ?? throw new InvalidOperationException("Connectionstring 'proiectChioranAndreiContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
options.SignIn.RequireConfirmedAccount = true)
 .AddEntityFrameworkStores<LibraryIdentityContext>();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
  //  .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
