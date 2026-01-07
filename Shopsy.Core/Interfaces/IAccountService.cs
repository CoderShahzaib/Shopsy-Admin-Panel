using Shopsy.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopsy.Core.Interfaces
{
    public interface IAccountService
    {
        Task<LoginResponseDTO?> LoginAsync(LoginRequestDTO request, string apiVersion = "1");
    }
}
