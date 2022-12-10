using Microsoft.AspNetCore.Identity;
using CovidService.Models;
namespace CovidService.Contracts
{
    public interface IUserServicesContract
    {
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
        Task<string> LoginAsync(SignInModel signInModel);
    }
}
