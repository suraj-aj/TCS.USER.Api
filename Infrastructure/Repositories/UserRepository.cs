using TCS.USER.Domain.Entities;
using TCS.USER.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TCS.USER.Infrastructure.Interfaces;

namespace TCS.USER.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
            //return users.Select(MapToDTO).ToList();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
           // return user != null ? MapToDTO(user) : null;
        }

        public async Task<User> CreateUserAsync(User userDTO)
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

        
    }
}
