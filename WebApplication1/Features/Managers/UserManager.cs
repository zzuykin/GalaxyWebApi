
using AutoMapper;
using Galaxy.Logic.Interfaces.Repositories;
using Galaxy.Storage.DataBase;
using Galaxy.Storage.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using WebApplication1.Features.Interfaces.Managers;
using WebApplication1.Features.ViewModels;

namespace WebApplication1.Features.Managers
{
    public class UserManager : IUserManager
    {
        private readonly DataContext _dataContext;
        private readonly IUserRepository _userRepository;
        private readonly IMapper mapper;

        public UserManager(DataContext dataContext, IUserRepository userRepository, IMapper mapper)
        {
            _dataContext = dataContext;
            _userRepository = userRepository;
            this.mapper = mapper;
        }

        public Guid Create(EditUser editUser)
        {
            var user = mapper.Map<User>(editUser);
            return _userRepository.Create(_dataContext, user).IsnNode;
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetByEmail(_dataContext,email);
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        public EditUser MakeEditUser(User user)
        {
            return mapper.Map<EditUser>(user);
        }

        
    }
}
