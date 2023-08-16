using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application.Interfaces
{
    public interface IOutfitService
    {
        Task CreateOutfit(Guid wardrobeId, Outfit outfit);
        Task DeleteOutfit(Guid id);
        Task<Outfit> GetOutfitById(Guid id);
        Task UpdateOutfit(Outfit outfit);
        Task<List<Outfit>> GetAllOutfits(Guid wardrobeId);
    }
}