using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence.RepositoryImplementations
{
    public class ClothingItemRepository : IClothingItemRepository
    {
        private readonly DataContext _context;

        public ClothingItemRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ClothingItem>> GetAllClothingItems(Guid wardrobeId)
        {
            return await _context.ClothingItems
           .Where(ci => ci.WardrobeId == wardrobeId)
           .ToListAsync();
        }
        public async Task CreateClothingItem(ClothingItem clothingItem)
        {
            _context.ClothingItems.Add(clothingItem);
            await _context.SaveChangesAsync();
        }

        public async Task<ClothingItem> GetById(Guid id)
        {
            return await _context.ClothingItems.FindAsync(id);
        }

        public async Task UpdateClothingItem(ClothingItem clothingItem)
        {
            _context.ClothingItems.Update(clothingItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClothingItem(Guid id)
        {
            var clothingItem = await _context.ClothingItems.FindAsync(id);
            if (clothingItem != null)
            {
                _context.ClothingItems.Remove(clothingItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}