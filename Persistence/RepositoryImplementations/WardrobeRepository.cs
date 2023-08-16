using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Persistence.RepositoryImplementations
{
    public class WardrobeRepository : IWardrobeRepository
    {
        private readonly DataContext _context;

        public WardrobeRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreateWardrobe(Wardrobe wardrobe)
        {
            _context.Wardrobes.Add(wardrobe);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteWardrobe(Guid id)
        {
            var wardrobe = await _context.Wardrobes.FindAsync(id);
            if (wardrobe != null)
            {
                _context.Wardrobes.Remove(wardrobe);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Wardrobe> GetByUser(string userId)
        {
            return await _context.Wardrobes
            .Include(w => w.ClothingItems)
            .Include(w => w.Outfits)
            .FirstOrDefaultAsync(w => w.User.Id == userId);
        }

        public async Task UpdateWardrobe(Wardrobe wardrobe)
        {
            _context.Wardrobes.Update(wardrobe);
            await _context.SaveChangesAsync();
        }
    }
}