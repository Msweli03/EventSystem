using EventSystem.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(
                Configuration.GetConnectionString("DefaultConnection")));

        services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddRazorPages();
        services.AddServerSideBlazor();

        // Add Google authentication (commented out)
        // services.AddAuthentication(options =>
        // {
        //     options.DefaultScheme = IdentityConstants.ApplicationScheme;
        //     options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        // })
        // .AddGoogle(options =>
        // {
        //     options.ClientId = "your-client-id";
        //     options.ClientSecret = "your-client-secret";
        //     options.CallbackPath = "/signin-google";
        // });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapBlazorHub();
            endpoints.MapFallbackToPage("/_Host");
        });
    }
}
