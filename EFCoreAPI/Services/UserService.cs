using EFCoreAPI.DtoModels;
using EFCoreAPI.Models;
using EFCoreAPI.Models.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;
        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserDto> CreateUserAsync(UserDto userToCreate)
        {
            var user = UserDto.MapFromUserDto(userToCreate);

            var userFromDb = await _dbContext.Users.SingleOrDefaultAsync(usr => usr.Id == user.Id);

            if (userFromDb != null)
            {
                userFromDb.Name = user.Name;
                userFromDb.LastName = user.LastName;
                userFromDb.Email = user.Email;
                userFromDb.DateOfBirth = user.DateOfBirth;

                userFromDb.UpdatedAt = DateTime.Now;

                await _dbContext.SaveChangesAsync();

                return UserDto.MapFromUser(userFromDb);
            }
            else
            {
                user.Id = Guid.NewGuid();
                user.CreatedAt = DateTime.Now;
                user.UpdatedAt = DateTime.Now;
                user.Active = true;

                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return UserDto.MapFromUser(user);
            }
        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
            var users = await _dbContext.Users.ToListAsync();

            var userDTOs = new List<UserDto>();

            foreach (var user in users)
            {
                userDTOs.Add(UserDto.MapFromUser(user));
            }

            return userDTOs;
        }
    }
}
