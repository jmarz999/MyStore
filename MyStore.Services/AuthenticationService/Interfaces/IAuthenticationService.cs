using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface IAuthenticationService
    {
        Task<string> SignInAsync(string email, string password);
        Task SignOutAsync();
    }
}
