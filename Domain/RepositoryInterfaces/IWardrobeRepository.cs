using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IWardrobeRepository
    {
        Task<Wardrobe> GetByUser(string username);
        Task CreateWardrobe(Wardrobe wardrobe);
        Task UpdateWardrobe(Wardrobe wardrobe);
        Task DeleteWardrobe(Guid id);
    }
}