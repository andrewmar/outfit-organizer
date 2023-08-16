using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using Domain.RepositoryInterfaces;

namespace Application.Services
{
    public class ClothingItemService : IClothingItemService
    {
        private readonly IClothingItemRepository _clothingItemRepository;

        public ClothingItemService(IClothingItemRepository clothingItemRepository)
        {
            _clothingItemRepository = clothingItemRepository;
        }

        public async Task CreateClothingItem(Guid wardrobeId, ClothingItem clothingItem)
        {
            clothingItem.WardrobeId = wardrobeId;
            await _clothingItemRepository.CreateClothingItem(clothingItem);
        }

        public async Task DeleteClothingItem(Guid id)
        {
            await _clothingItemRepository.DeleteClothingItem(id);
        }

        public async Task<ClothingItem> GetClothingItemById(Guid id)
        {
            return await _clothingItemRepository.GetById(id);
        }

        public async Task UpdateClothingItem(ClothingItem clothingItem)
        {
            await _clothingItemRepository.UpdateClothingItem(clothingItem);
        }

        public async Task<List<ClothingItem>> GetAllClothingItems(Guid wardrobeId)
        {
            return await _clothingItemRepository.GetAllClothingItems(wardrobeId);
        }
    }
}