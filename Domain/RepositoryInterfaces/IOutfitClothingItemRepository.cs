using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IOutfitClothingItemRepository
    {
        Task AddItemToOutfit(Guid outfitId, Guid clothingItemId);
        Task RemoveItemFromOutfit(Guid outfitId, Guid clothingItemId);
        Task<List<ClothingItem>> GetItemsForOutfit(Guid outfitId);
        Task<List<Outfit>> GetOutfitsForItem(Guid clothingItemId);
    }
}