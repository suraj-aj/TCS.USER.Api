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
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            user.Id = user.Id;
            user.CreatedAt = user.CreatedAt;
            user.UpdatedAt = user.UpdatedAt;

            return user;
        }

        
    }
}
