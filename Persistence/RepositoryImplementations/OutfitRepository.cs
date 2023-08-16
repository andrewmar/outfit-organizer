using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence.RepositoryImplementations
{
    public class OutfitRepository : IOutfitRepository
    {
        private readonly DataContext _context;
        public OutfitRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreateOutfit(Outfit outfit)
        {
            _context.Outfits.Add(outfit);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOutfit(Guid id)
        {
            var outfit = await _context.Outfits.FindAsync(id);
            if (outfit != null)
            {
                _context.Outfits.Remove(outfit);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Outfit> GetOutfitById(Guid id)
        {
            return await _context.Outfits.FindAsync(id);
        }

        public async Task UpdateOutfit(Outfit outfit)
        {
            _context.Outfits.Update(outfit);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Outfit>> GetAllOutfits(Guid wardrobeId)
        {
            return await _context.Outfits
            .Where(o => o.WardrobeId == wardrobeId)
            .ToListAsync();
        }
    }
}