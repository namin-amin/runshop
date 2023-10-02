using runShop.Models.models;

namespace runShop.rest.Dtos.user
{
    public class UserResponseDto: BaseModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
