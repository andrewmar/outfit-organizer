using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Services;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.RepositoryImplementations;
using Infrastructure.Security;
using Application.Profiles;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<DataContext>(options => options.UseNpgsql(config["Wardrobe:ConnectionString"]));
            services.AddScoped<IWardrobeRepository, WardrobeRepository>();
            services.AddScoped<IClothingItemRepository, ClothingItemRepository>();
            services.AddScoped<IOutfitRepository, OutfitRepository>();
            services.AddScoped<IOutfitClothingItemRepository, OutfitClothingItemRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IWardrobeService, WardrobeService>();
            services.AddScoped<IClothingItemService, ClothingItemService>();
            services.AddScoped<IOutfitService, OutfitService>();
            services.AddScoped<IOutfitClothingItemService, OutfitClothingItemService>();
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddHttpContextAccessor();
            services.AddScoped<IUserAccessor, UserAccessor>();
            return services;
        }
    }
}