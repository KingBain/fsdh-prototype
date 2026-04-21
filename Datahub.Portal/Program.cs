
using System.Security.Claims;
using Datahub.Portal.Scaffold;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMudServices();

builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "Datahub.Scaffold.Auth";
        options.LoginPath = PageRoutes.Login;
        options.AccessDeniedPath = PageRoutes.AccessDenied;
        options.SlidingExpiration = true;
    });

builder.Services.AddAuthorization();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(PageRoutes.NotFound);
    app.UseHsts();
}

app.UseStaticFiles();
app.UseStatusCodePagesWithReExecute(PageRoutes.NotFound);
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapPost("/auth/login", async (HttpContext context) =>
{
    var form = await context.Request.ReadFormAsync();
    var email = form["email"].ToString().Trim();
    var returnUrl = NormalizeReturnUrl(form["returnUrl"].ToString());

    if (string.IsNullOrWhiteSpace(email))
    {
        context.Response.Redirect($"{PageRoutes.Login}?error=missing-email");
        return;
    }

    // TODO: Replace scaffold cookie auth with the real authentication flow when backend services return.
    var claims = new List<Claim>
    {
        new(ClaimTypes.Name, email),
        new(ClaimTypes.Email, email),
        new(ClaimTypes.GivenName, email.Split('@')[0]),
        new(ClaimTypes.Role, "ScaffoldUser")
    };

    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
    var principal = new ClaimsPrincipal(identity);

    await context.SignInAsync(
        CookieAuthenticationDefaults.AuthenticationScheme,
        principal,
        new AuthenticationProperties
        {
            IsPersistent = true,
            ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8)
        });

    context.Response.Redirect(returnUrl);
});

app.MapGet(PageRoutes.Logout, async (HttpContext context) =>
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    context.Response.Redirect(PageRoutes.Home);
});

app.MapGet("/logout", async (HttpContext context) =>
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    context.Response.Redirect(PageRoutes.Home);
});

app.MapRazorComponents<App>();

app.Run();

static string NormalizeReturnUrl(string? returnUrl)
{
    if (string.IsNullOrWhiteSpace(returnUrl))
    {
        return PageRoutes.Home;
    }

    if (!returnUrl.StartsWith('/'))
    {
        return PageRoutes.Home;
    }

    if (returnUrl.StartsWith("//", StringComparison.Ordinal))
    {
        return PageRoutes.Home;
    }

    return returnUrl;
}
