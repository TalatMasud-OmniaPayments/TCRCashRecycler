using Geidea.TCR.Model.Data;
using Geidea.TCR.Model.Data.Enum;
using Geidea.TCR.Service.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using TCRServiceTestClient.Framework;
using TCRServiceTestClient.FrameworkInterface;
using TestTCRApp.Models;

namespace TestTCRApp
{
    public class Startup
    {

        private static Logger log = LogManager.GetCurrentClassLogger();
        public static IConfiguration StaticConfig { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            StaticConfig = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<TestTCRModelContext>(opt => opt.UseInMemoryDatabase("TCRList"));
            services.AddControllers();
            OnStart();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void OnStart()
        {
            log.Info("Service Starting up");


            /*if (mScheduler == null)
                mScheduler = new HostScheduler();
            
            mScheduler.Start();*/


            //CreateJSON();
        }

        
    }
}
