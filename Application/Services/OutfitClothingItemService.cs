using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using Domain.RepositoryInterfaces;

namespace Application.Services
{
    public class OutfitClothingItemService : IOutfitClothingItemService
    {
        private readonly IOutfitClothingItemRepository _outfitClothingItemRepository;

        public OutfitClothingItemService(IOutfitClothingItemRepository outfitClothingItemRepository)
        {
            _outfitClothingItemRepository = outfitClothingItemRepository;
        }

        public async Task AddItemToOutfit(Guid outfitId, Guid clothingItemId)
        {
            await _outfitClothingItemRepository.AddItemToOutfit(outfitId, clothingItemId);
        }

        public async Task RemoveItemFromOutfit(Guid outfitId, Guid clothingItemId)
        {
            await _outfitClothingItemRepository.RemoveItemFromOutfit(outfitId, clothingItemId);
        }

        public async Task<List<ClothingItem>> GetItemsForOutfit(Guid outfitId)
        {
            return await _outfitClothingItemRepository.GetItemsForOutfit(outfitId);
        }

        public async Task<List<Outfit>> GetOutfitsForItem(Guid clothingItemId)
        {
            return await _outfitClothingItemRepository.GetOutfitsForItem(clothingItemId);
        }
    }
}