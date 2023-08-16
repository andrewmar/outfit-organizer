using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IOutfitRepository
    {
        Task<List<Outfit>> GetAllOutfits(Guid wardrobeId);
        Task CreateOutfit(Outfit Outfit);
        Task<Outfit> GetOutfitById(Guid id);
        Task UpdateOutfit(Outfit Outfit);
        Task DeleteOutfit(Guid id);
    }
}