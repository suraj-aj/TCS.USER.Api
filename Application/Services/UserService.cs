using TCS.USER.Application.DTOs;
using TCS.USER.Application.Interfaces;
using TCS.USER.Domain.Entities;
using TCS.USER.Infrastructure.Interfaces;

namespace TCS.USER.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return users.Select(MapToDTO).ToList();

        }

        public async Task<UserDTO?> GetUserByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("User ID must be greater than 0", nameof(id));

            var user = await _userRepository.GetUserByIdAsync(id);
            return user != null ? MapToDTO(user) : null;
        }

        public async Task<UserDTO> CreateUserAsync(UserDTO userDTO)
        {
            if (userDTO == null)
                throw new ArgumentNullException(nameof(userDTO));

            ValidateUserDTO(userDTO);

            var userEntity = new User
            {
                Name = userDTO.Name,
                Age = userDTO.Age,
                City = userDTO.City,
                State = userDTO.State,
                Pincode = userDTO.Pincode,
                CreatedAt = DateTime.UtcNow
            };

            var user = await _userRepository.CreateUserAsync(userEntity);
            return MapToDTO(user);

        }

        private static void ValidateUserDTO(UserDTO userDTO)
        {
            if (string.IsNullOrWhiteSpace(userDTO.Name) || userDTO.Name.Length < 2 || userDTO.Name.Length > 100)
                throw new ArgumentException("Name must be between 2 and 100 characters", nameof(userDTO.Name));

            if (userDTO.Age < 0 || userDTO.Age > 120)
                throw new ArgumentException("Age must be between 0 and 120", nameof(userDTO.Age));

            if (string.IsNullOrWhiteSpace(userDTO.City))
                throw new ArgumentException("City is required", nameof(userDTO.City));

            if (string.IsNullOrWhiteSpace(userDTO.State))
                throw new ArgumentException("State is required", nameof(userDTO.State));

            if (string.IsNullOrWhiteSpace(userDTO.Pincode) || userDTO.Pincode.Length < 4 || userDTO.Pincode.Length > 10)
                throw new ArgumentException("Pincode must be between 4 and 10 characters", nameof(userDTO.Pincode));
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
