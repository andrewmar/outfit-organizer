using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using Domain.RepositoryInterfaces;

namespace Application.Services
{
    public class OutfitService : IOutfitService
    {
        private readonly IOutfitRepository _outfitRepository;

        public OutfitService(IOutfitRepository outfitRepository)
        {
            _outfitRepository = outfitRepository;
        }

        public async Task CreateOutfit(Guid wardrobeId, Outfit outfit)
        {
            outfit.WardrobeId = wardrobeId;
            await _outfitRepository.CreateOutfit(outfit);
        }

        public async Task DeleteOutfit(Guid id)
        {
            await _outfitRepository.DeleteOutfit(id);
        }

        public async Task<Outfit> GetOutfitById(Guid id)
        {
            return await _outfitRepository.GetOutfitById(id);
        }

        public async Task UpdateOutfit(Outfit outfit)
        {
            await _outfitRepository.UpdateOutfit(outfit);
        }

        public async Task<List<Outfit>> GetAllOutfits(Guid wardrobeId)
        {
            return await _outfitRepository.GetAllOutfits(wardrobeId);
        }
    }
}

