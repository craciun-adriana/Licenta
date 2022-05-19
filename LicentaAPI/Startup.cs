using LicentaAPI.AppServices.Appointments;
using LicentaAPI.AppServices.Books;
using LicentaAPI.AppServices.Films;
using LicentaAPI.AppServices.Friendships;
using LicentaAPI.AppServices.GroupMembers;
using LicentaAPI.AppServices.Groups;
using LicentaAPI.AppServices.Messages;
using LicentaAPI.AppServices.ReviewBooks;
using LicentaAPI.AppServices.ReviewFilms;
using LicentaAPI.AppServices.ReviewSerieses;
using LicentaAPI.AppServices.Serieses;
using LicentaAPI.AppServices.Users;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence;
using LicentaAPI.Persistence.Models;
using LicentaAPI.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using System.Text.Json.Serialization;

namespace LicentaAPI
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
            AddDbContext(services);
            AddAuthentication(services);
            AddRepositories(services);
            AddServices(services);
            ConfigureControllers(services);
            AddSwagger(services);
            AddUtilities(services);
        }

        private void AddDbContext(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                string path = Directory.GetCurrentDirectory();
                string dbPath = Configuration.GetValue<string>("Db");
                if (dbPath.Contains(":"))
                {
                    path = dbPath;
                }
                else
                {
                    path += "\\" + dbPath;
                }
                var connectionString = $"Data Source={path};";
                opt.UseSqlite(connectionString);
            });
        }

        private static void AddAuthentication(IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 2;
                options.Password.RequireNonAlphanumeric = false;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.RequireUniqueEmail = true;

                // TODO: remove this once an email sender is implemented.
                options.SignIn.RequireConfirmedAccount = false;
            });

            // Set how much time is needed to logout the user after inactivity.
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(24);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IAppointmentRepo, EFAppointmentRepository>();
            services.AddScoped<IBookRepo, EFBookRepository>();
            services.AddScoped<IFilmRepo, EFFilmRepository>();
            services.AddScoped<IFriendshipRepo, EFFriendshipRepository>();
            services.AddScoped<IGroupMemberRepo, EFGroupMemberRepository>();
            services.AddScoped<IGroupRepo, EFGroupRepository>();
            services.AddScoped<IMessageRepo, EFMessageRepository>();
            services.AddScoped<IReviewBookRepo, EFReviewBookRepository>();
            services.AddScoped<IReviewFilmRepo, EFReviewFilmRepository>();
            services.AddScoped<IReviewSeriesRepo, EFReviewSeriesRepository>();
            services.AddScoped<ISeriesRepo, EFSeriesRepository>();
            services.AddScoped<IUserRepo, EFUserRepository>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IFilmService, FilmService>();
            services.AddScoped<IFriendshipService, FriendshipService>();
            services.AddScoped<IGroupMemberService, GroupMemberService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IReviewBookService, ReviewBookService>();
            services.AddScoped<IReviewFilmService, ReviewFilmService>();
            services.AddScoped<IReviewSeriesService, ReviewSeriesService>();
            services.AddScoped<ISeriesService, SeriesService>();
            services.AddScoped<IUserService, UserService>();
        }

        private static void ConfigureControllers(IServiceCollection services)
        {
            // Makes testing easier.
            services.AddCors(opt =>
            {
                opt.AddPolicy("AllowOrigin", options =>
                {
                    options.AllowAnyOrigin();
                    options.AllowAnyHeader();
                    options.AllowAnyMethod();
                });
            });

            services.AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
        }

        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Licenta API",
                    Version = "v1",
                    Description = $"An API created in ASP.NET Core 5.",
                    Contact = new OpenApiContact
                    {
                        Name = "Craciun Adriana Maria",
                        Email = string.Empty
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.EnableAnnotations();
            });
        }

        private static void AddUtilities(IServiceCollection services)
        {
            services.AddSingleton<IMappingCoordinator, MappingCoordinator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LicentaAPI v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("AllowOrigin");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}