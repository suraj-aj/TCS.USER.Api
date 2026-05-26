using TCS.USER.Application.DTOs;
using TCS.USER.Application.Interfaces;
using TCS.USER.Domain.Entities;
using TCS.USER.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace TCS.USER.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users.Select(MapToDTO).ToList();
        }

        public async Task<UserDTO?> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user != null ? MapToDTO(user) : null;
        }

        public async Task<UserDTO> CreateUserAsync(UserDTO userDTO)
        {
            var user = new User
            {
                Name = userDTO.Name,
                Age = userDTO.Age,
                City = userDTO.City,
                State = userDTO.State,
                Pincode = userDTO.Pincode,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            userDTO.Id = user.Id;
            userDTO.CreatedAt = user.CreatedAt;
            userDTO.UpdatedAt = user.UpdatedAt;

            return userDTO;
        }

        public async Task<UserDTO?> UpdateUserAsync(int id, UserDTO userDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
                return null;

            user.Name = userDTO.Name;
            user.Age = userDTO.Age;
            user.City = userDTO.City;
            user.State = userDTO.State;
            user.Pincode = userDTO.Pincode;
            user.UpdatedAt = DateTime.UtcNow;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return MapToDTO(user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        private static UserDTO MapToDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age,
                City = user.City,
                State = user.State,
                Pincode = user.Pincode,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }
    }
}
