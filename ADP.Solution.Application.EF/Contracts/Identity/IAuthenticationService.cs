using ADP.Solution.Application.Models.Authenticaiton;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ADP.Solution.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}
