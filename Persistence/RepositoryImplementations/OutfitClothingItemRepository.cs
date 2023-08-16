using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence.RepositoryImplementations
{
    public class OutfitClothingItemRepository : IOutfitClothingItemRepository
    {
        private readonly DataContext _context;

        public OutfitClothingItemRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddItemToOutfit(Guid outfitId, Guid clothingItemId)
        {
            var outfitClothingItem = new OutfitClothingItem
            {
                OutfitId = outfitId,
                ClothingItemId = clothingItemId
            };

            _context.OutfitClothingItem.Add(outfitClothingItem);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveItemFromOutfit(Guid outfitId, Guid clothingItemId)
        {
            var outfitClothingItem = await _context.OutfitClothingItem
                .FirstOrDefaultAsync(oci => oci.OutfitId == outfitId && oci.ClothingItemId == clothingItemId);

            if (outfitClothingItem != null)
            {
                _context.OutfitClothingItem.Remove(outfitClothingItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ClothingItem>> GetItemsForOutfit(Guid outfitId)
        {
            var clothingItemIds = await _context.OutfitClothingItem
                .Where(oci => oci.OutfitId == outfitId)
                .Select(oci => oci.ClothingItemId)
                .ToListAsync();

            var clothingItems = await _context.ClothingItems
                .Where(ci => clothingItemIds.Contains(ci.Id))
                .ToListAsync();

            return clothingItems;
        }

        public async Task<List<Outfit>> GetOutfitsForItem(Guid clothingItemId)
        {
            var outfitIds = await _context.OutfitClothingItem
                .Where(oci => oci.ClothingItemId == clothingItemId)
                .Select(oci => oci.OutfitId)
                .ToListAsync();

            var outfits = await _context.Outfits
                .Where(o => outfitIds.Contains(o.Id))
                .ToListAsync();

            return outfits;
        }
    }
}