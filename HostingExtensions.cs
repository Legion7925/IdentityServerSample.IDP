using Marvin.IDP.DbContexts;
using Marvin.IDP.Entities;
using Marvin.IDP.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TTech.IDP.Services;

namespace TTech.IDP;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<IISOptions>(options =>
        {
            options.AuthenticationDisplayName = "Windows";
            options.AutomaticAuthentication = false;
        });
        builder.Services.Configure<IISServerOptions>(options =>
        {
            options.AutomaticAuthentication = false;
            options.AuthenticationDisplayName = "Windows";
        });

        // uncomment if you want to add a UI
        builder.Services.AddRazorPages();

        builder.Services.AddScoped<ILocalUserService, LocalUserService>();
        builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

        builder.Services.AddDbContext<IdentityDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("AppData"));
        });

        builder.Services.AddIdentityServer(options =>
            {
                options.EmitStaticAudienceClaim = true;
            })
            .AddProfileService<LocalUserProfileService>()
            .AddInMemoryIdentityResources(Config.IdentityResources)
            .AddInMemoryApiScopes(Config.ApiScopes)
            .AddInMemoryApiResources(Config.ApiResources)
            .AddInMemoryClients(Config.Clients);

        return builder.Build();
    }
    
    public static WebApplication ConfigurePipeline(this WebApplication app)
    { 
        app.UseSerilogRequestLogging();
    
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // uncomment if you want to add a UI
        app.UseStaticFiles();
        app.UseRouting();

        app.UseIdentityServer();

        // uncomment if you want to add a UI
        app.UseAuthorization();
        app.MapRazorPages().RequireAuthorization();

        return app;
    }
}
