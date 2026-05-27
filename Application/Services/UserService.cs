using TCS.USER.Application.DTOs;
using TCS.USER.Application.Interfaces;

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
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<UserDTO?> GetUserByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("User ID must be greater than 0", nameof(id));

            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<UserDTO> CreateUserAsync(UserDTO userDTO)
        {
            if (userDTO == null)
                throw new ArgumentNullException(nameof(userDTO));

            ValidateUserDTO(userDTO);

            return await _userRepository.CreateUserAsync(userDTO);
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
    }
}
