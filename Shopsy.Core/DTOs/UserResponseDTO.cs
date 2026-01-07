using System;
using System.Collections.Generic;
using System.Text;

namespace Shopsy.Core.DTOs
{
    public class UserResponseDTO
    {
        public Guid Id { get; set; }
        public string PersonName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
    }
}
