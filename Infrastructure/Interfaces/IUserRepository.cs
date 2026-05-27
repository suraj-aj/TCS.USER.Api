using System;
using System.Collections.Generic;
using System.Text;
using TCS.USER.Domain.Entities;

namespace TCS.USER.Infrastructure.Interfaces
{
    public  interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
    }
}
