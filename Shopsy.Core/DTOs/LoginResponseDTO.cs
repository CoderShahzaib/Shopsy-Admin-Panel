using System;
using System.Collections.Generic;
using System.Text;

namespace Shopsy.Core.DTOs
{
    public class LoginResponseDTO
    {
        public string Message { get; set; } = default!;
        public bool Result { get; set; }
        public LoginDataDto? Data { get; set; }
    }

    public class TokenDto
    {
        public string Token { get; set; } = default!;
        public DateTime Expiration { get; set; }
    }

    public class LoginDataDto
    {
        public TokenDto Token { get; set; } = default!;
        public UserDTO User { get; set; } = default!;
    }

    public class UserDto
    {
        public string PersonName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Token { get; set; } = default!;
        public DateTime Expiration { get; set; }
    }
    public class UserDTO
    {
        public string Id { get; set; } = default!;
        public string PersonName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public List<string> Roles { get; set; } = new();
    }
}
