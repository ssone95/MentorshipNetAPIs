using EFCoreAPI.DtoModels;
using EFCoreAPI.Models;

namespace EFCoreAPI.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUsersAsync();
        Task<UserDto> CreateUserAsync(UserDto userToCreate);
    }
}
