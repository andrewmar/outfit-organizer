using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using Domain.RepositoryInterfaces;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task CreateUser(User user)
        {
            await _userRepository.CreateUser(user);
        }

        public async Task DeleteUser(Guid id)
        {
            await _userRepository.DeleteUser(id);
        }

        public async Task<UserDto> GetUserById(Guid id)
        {
            var user = await _userRepository.GetUserById(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task UpdateUser(User user)
        {
            await _userRepository.UpdateUser(user);
        }
    }
}