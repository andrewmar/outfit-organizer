using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using Domain.RepositoryInterfaces;

namespace Application.Services
{
    public class WardrobeService : IWardrobeService
    {
        private readonly IWardrobeRepository _wardrobeRepository;
        private readonly IUserAccessor _userAccessor;

        public WardrobeService(IWardrobeRepository wardrobeRepository, IUserAccessor userAccessor)
        {
            _wardrobeRepository = wardrobeRepository;
            _userAccessor = userAccessor;
        }

        public async Task CreateWardrobe(Wardrobe wardrobe)
        {
            string usernameId = _userAccessor.GetUserId();
            wardrobe.UserId = usernameId;
            wardrobe.ClothingItems = new List<ClothingItem>();
            wardrobe.Outfits = new List<Outfit>();
            await _wardrobeRepository.CreateWardrobe(wardrobe);
        }

        public async Task UpdateWardrobe(Wardrobe wardrobe)
        {
            await _wardrobeRepository.UpdateWardrobe(wardrobe);
        }

        public async Task DeleteWardrobe(Guid id)
        {
            await _wardrobeRepository.DeleteWardrobe(id);
        }

        public async Task<Wardrobe> GetWardrobeByUser()
        {
            string usernameId = _userAccessor.GetUserId();
            return await _wardrobeRepository.GetByUser(usernameId);

        }
    }
}