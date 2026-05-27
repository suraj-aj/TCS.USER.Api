using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TCS.USER.Application.DTOs;
using TCS.USER.Application.Interfaces;

namespace TCS.USER.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>List of all users</returns>
        /// <response code="200">Returns the list of users</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            try
            {
                _logger.LogInformation("Fetching all users");
                var users = await _userService.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all users");
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    new { message = "An error occurred while fetching users", error = ex.Message });
            }
        }

        /// <summary>
        /// Get a user by ID
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User details</returns>
        /// <response code="200">Returns the user</response>
        /// <response code="404">User not found</response>
        /// <response code="400">Invalid user ID</response>
        /// <response code="500">Internal server error</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    _logger.LogWarning("Invalid user ID requested: {UserId}", id);
                    return BadRequest(new { message = "User ID must be greater than 0" });
                }

                _logger.LogInformation("Fetching user with ID: {UserId}", id);
                var user = await _userService.GetUserByIdAsync(id);

                if (user == null)
                {
                    _logger.LogWarning("User not found with ID: {UserId}", id);
                    return NotFound(new { message = $"User with ID {id} not found" });
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching user with ID: {UserId}", id);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "An error occurred while fetching the user", error = ex.Message });
            }
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="userDTO">User data</param>
        /// <returns>Created user with ID</returns>
        /// <response code="201">User created successfully</response>
        /// <response code="400">Invalid user data</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] UserDTO userDTO)
        {
            try
            {
                if (userDTO == null)
                {
                    _logger.LogWarning("Create user request with null data");
                    return BadRequest(new { message = "User data is required" });
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Invalid user data provided");
                    return BadRequest(ModelState);
                }

                _logger.LogInformation("Creating new user: {UserName}", userDTO.Name);
                var createdUser = await _userService.CreateUserAsync(userDTO);

                return CreatedAtAction("Creted succesfully", new { id = createdUser.Id }, createdUser);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Validation error while creating user");
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating user");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "An error occurred while creating the user", error = ex.Message });
            }
        }
    }
}
