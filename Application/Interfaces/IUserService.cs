using TCS.USER.Application.DTOs;

namespace TCS.USER.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO?> GetUserByIdAsync(int id);
        Task<UserDTO> CreateUserAsync(UserDTO userDTO);
    }
}
