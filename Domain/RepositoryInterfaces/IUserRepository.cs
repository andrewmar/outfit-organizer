using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task<User> GetUserById(Guid id);
        Task UpdateUser(User user);
        Task DeleteUser(Guid id);
    }
}