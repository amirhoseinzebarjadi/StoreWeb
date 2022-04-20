using System;
using Marina_Club.Context;
using Marina_Club.Repositories.Counter;
using Marina_Club.Repositories.Customer;
using Marina_Club.Repositories.Report;
using Marina_Club.Repositories.Sans;
using Marina_Club.Repositories.SellerManager;
using Marina_Club.Repositories.SellerPanel;
using Marina_Club.Repositories.Setting;
using Marina_Club.Repositories.SiteManagement;
using Marina_Club.Repositories.Ticket;
using Marina_Club.Repositories.WaterFun;
using Marina_Club.Services.Counter;
using Marina_Club.Services.Customer;
using Marina_Club.Services.Report;
using Marina_Club.Services.Sans;
using Marina_Club.Services.SellerManager;
using Marina_Club.Services.SellerPanel;
using Marina_Club.Services.Setting;
using Marina_Club.Services.SiteManagement;
using Marina_Club.Services.Ticket;
using Marina_Club.Services.WaterFun;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Marina_Club
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<MarinaClubContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Db")));
            services.AddScoped<IWaterFunService, WaterFunService>();
            services.AddScoped<IWaterFunRepository, WaterFunRepository>();
            services.AddScoped<ISiteManagementService, SiteManagementService>();
            services.AddScoped<ISiteManagementRepository, SiteManagementRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ISellerManagerService, SellerManagerService>();
            services.AddScoped<ISellerManagerRepository, SellerManagerRepository>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<ISettingRepository, SettingRepository>();
            services.AddScoped<ICounterService, CounterService>();
            services.AddScoped<ICounterRepository, CounterRepository>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ISellerPanelService, SellerPanelService>();
            services.AddScoped<ISellerPanelRepository, SellerPanelRepository>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<ISansService, SansService>();
            services.AddScoped<ISansRepository, SansRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            provider.MigrateDatabases();
            app.UseMvc();
        }
    }
}
