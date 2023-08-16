using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Domain;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(Guid id);
        Task<UserDto> GetUserById(Guid id);
    }
}