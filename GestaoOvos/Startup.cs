using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using GestaoOvos.Data;
using GestaoOvos.Services;
using GestaoOvos.Services.VendedorService;
using Microsoft.AspNetCore.Authentication.Cookies;
using GestaoOvos.Models;
using Microsoft.AspNetCore.Identity;
using System;
using GestaoOvos.Services.Interface;

namespace GestaoOvos
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
            services.AddControllers();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(options =>
            //    {
            //        options.LoginPath = new PathString("/Login/Index/"); //401-Unouthorized
            //        options.AccessDeniedPath = new PathString("/Error/Index/"); //403-Forbidden
            //    });

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddMvc();

            services.AddDbContext<GestaoOvosContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("GestaoOvosContext"), builder =>
                    builder.MigrationsAssembly("GestaoOvos")));
            services.AddIdentity<Usuario, IdentityRole>()
                .AddEntityFrameworkStores<GestaoOvosContext>()
                .AddDefaultTokenProviders();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<VendedorService>();
            services.AddScoped<VendaService>();
            services.AddScoped<ClienteService>();
            services.AddScoped<ProdutoService>();
            services.AddScoped<StatusPgtoService>();
            services.AddScoped<StatusEntregaService>();
            services.AddScoped<FormaPagamentoService>();
            services.AddScoped<QuantidadeService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Vendas}/{action=Index}/{id?}");
            });


        }
    }
}
