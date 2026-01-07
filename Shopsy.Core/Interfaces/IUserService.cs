using Shopsy.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopsy.Core.Interfaces
{
    public interface IUserService
    {
        Task<List<UserResponseDTO>> GetAllUsersAsync();

        Task<bool> DeleteUserAsync(Guid id);

    }
}
