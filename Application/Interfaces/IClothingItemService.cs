using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application.Interfaces
{
    public interface IClothingItemService
    {
        Task CreateClothingItem(Guid wardrobeId, ClothingItem clothingItem);
        Task DeleteClothingItem(Guid id);
        Task<ClothingItem> GetClothingItemById(Guid id);
        Task UpdateClothingItem(ClothingItem clothingItem);
        Task<List<ClothingItem>> GetAllClothingItems(Guid wardrobeId);
    }
}