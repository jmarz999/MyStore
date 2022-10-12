using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MyStore.Middleware;
using MyStore.Models;
using MyStore.Models.EntityFramework;
using MyStore.Repositories;
using MyStore.Services;

namespace MyStore
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
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyStore", Version = "v1" });
            });

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MyStoreDB"));
            });

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MyStoreDB")), ServiceLifetime.Transient);

            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = true;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = true;
            });

            services.AddTransient<IProductRepo, ProductRepo>();
            services.AddTransient<IProductAppService, ProductAppService>();
            services.AddTransient<IOrderRepo, OrderRepo>();
            services.AddTransient<IOrderAppService, OrderAppService>();
            services.AddTransient<IProductOrdersRepo, ProductOrdersRepo>();
            services.AddTransient<IUserAppService, UserAppService>();
            services.AddTransient<IAuthService, AuthService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseSwagger();

            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("v1/swagger.json", "MyStore v1");
            });

            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}