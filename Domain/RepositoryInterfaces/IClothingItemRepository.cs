using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IClothingItemRepository
    {
        Task<List<ClothingItem>> GetAllClothingItems(Guid wardrobeId);
        Task CreateClothingItem(ClothingItem clothingItem);
        Task<ClothingItem> GetById(Guid id);
        Task UpdateClothingItem(ClothingItem clothingItem);
        Task DeleteClothingItem(Guid id);
    }
}