using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using System.Diagnostics.CodeAnalysis;
using Transparity.Data;

namespace Transparity.Api {
    public class DependencyInjection {
        public static void ConfigureConfiguration(IConfigurationManager config) {
            config.AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
        }

        public static void ConfigureServices(IServiceCollection services, IConfiguration config) {
            services.AddOpenApi(options => {
                options.AddDocumentTransformer((document, context, _) => {
                    document.Info = new() {
                        Title = "Transparity API documentation",
                        Version = "v1"
                    };

                    return Task.CompletedTask;
                });
            });

            services.AddControllers();
            services.AddEndpointsApiExplorer();

            // Add mediator registry here
            // Add fluent validation registry here

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(config.GetConnectionString("NeonTransparity")));

            services.AddCors(options => {
                options.AddDefaultPolicy(policy => {
                    policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }

        [SuppressMessage("Usage", "ASP0014:Suggest using top level route registrations", 
            Justification = "app.UseEndpoints(...): This is just to handle the " +
            "fallback logic when someone tries to search API routes randomly")]
        public static void ConfigureApplication(WebApplication app, IWebHostEnvironment env) {
            if (!env.IsEnvironment("Production")) {
                app.MapOpenApi();
                app.MapScalarApiReference();

                app.MapGet("/", () => Results.Redirect("/scalar/v1"))
                    .ExcludeFromDescription();
            }

            app.UseCors();

            // Add middleware/s here that "IS NOT" endpoint/route context reliant

            app.UseRouting();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
                endpoints.MapFallback(context => {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;

                    return context.Response
                        .WriteAsJsonAsync(string.Empty);
                });
            });

            // Add middleware/s here that "IS" endpoint/route context reliant

            using var scope = app.Services
                .CreateScope();

            scope.ServiceProvider
                .GetRequiredService<ApplicationDbContext>()
                .Database
                .Migrate();
        }
    }
}
