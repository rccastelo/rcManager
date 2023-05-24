using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using diPermission = rcManagerPermissionApplication.DI.Configure;
using diSystem = rcManagerSystemApplication.DI.Configure;
using diUser = rcManagerUserApplication.DI.Configure;
using diLog4Net = rcLogs_Log4Net.Configure;
using diSerilog = rcLogs_Serilog.Configure;

namespace rcManagerApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", builder => {
                builder.AllowAnyOrigin().
                    AllowAnyMethod().
                    AllowAnyHeader();
            }));

            services.AddControllers();

            diUser.ConfigureServices(services);
            diSystem.ConfigureServices(services);
            diPermission.ConfigureServices(services);

            switch (Configuration.GetValue<string>("LogType")) {
                case "serilog":
                    diSerilog.ConfigureServices(services);
                    break;
                case "log4net":
                default:
                    diLog4Net.ConfigureServices(services);
                    break;
            }

            Authentication.SetAuthentication(services, Configuration);
            Swagger.SetSwagger(services, Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(ui => {
                ui.SwaggerEndpoint("../swagger/v1/swagger.json", "v1");
                ui.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("MyPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
