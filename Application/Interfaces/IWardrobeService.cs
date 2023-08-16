using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Domain;

namespace Application.Interfaces
{
    public interface IWardrobeService
    {
        Task CreateWardrobe(Wardrobe wardrobe);
        Task UpdateWardrobe(Wardrobe wardrobe);
        Task DeleteWardrobe(Guid id);
        Task<Wardrobe> GetWardrobeByUser();
    }
}