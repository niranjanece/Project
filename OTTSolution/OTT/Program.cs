using Microsoft.EntityFrameworkCore;
using OTT.Context;
using OTT.Interfaces;
using OTT.Models;
using OTT.Repositories;
using OTT.Services;

namespace OTT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddControllersWithViews();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<OTTContext>(opts =>
            {
                opts.UseSqlServer(builder.Configuration.GetConnectionString("ottCon"));
            });

            builder.Services.AddScoped<IRepository<string, User>, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IRepository<int, Movie>, MovieRepository>();
            builder.Services.AddScoped<IMovieService, MovieService>();
            builder.Services.AddScoped<IRepository<int, SubscriptionPlan>, SubscriptionPlanRepository>();
            builder.Services.AddScoped<ISubscriptionPlanService, SubscriptionPlanService>();
            builder.Services.AddScoped<IRepository<string, UserSubscription>, UserSubscriptionRepository>();
            builder.Services.AddScoped<IUserSubscriptionService, UserSubscriptionService>();
            builder.Services.AddScoped<IRepository<int, WatchList>, WatchListRepository>();
            builder.Services.AddScoped<IWatchListService, WatchListService>();
            builder.Services.AddScoped<IRepository<int, WatchHistory>, WatchHistoryRepository>();
            builder.Services.AddScoped<IWatchHistoryService, WatchHistoryService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

           

            app.MapControllers();

            app.Run();
        }
    }
}