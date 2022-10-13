using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface IAuthService
    {
        Task<AuthenticateResponse> LogInAsync(string email, string password);
        Task LogOutAsync();
    }
}
