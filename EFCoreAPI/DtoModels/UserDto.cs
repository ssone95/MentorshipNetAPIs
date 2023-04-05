using EFCoreAPI.Models;

namespace EFCoreAPI.DtoModels
{
    public class UserDto : IUpdateable
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Active { get; set; }


        public static UserDto MapFromUser(User user)
        {
            return new()
            {
                Id = user.Id,
                Active = user.Active,
                Name = user.Name,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }
        public static User MapFromUserDto(UserDto user)
        {
            return new()
            {
                Id = user.Id,
                Active = user.Active,
                Name = user.Name,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }
    }
}
