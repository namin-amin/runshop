﻿namespace runShop.rest.Dto.user
{
    public class CreateUserDto
    {
        public string FirstName { get; set; } =string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
