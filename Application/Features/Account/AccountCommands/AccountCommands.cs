using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Account.AccountCommands
{
    public class AccountCommands
    {
        public class RegisterCommand: IRequest<RegisterCommandResponse>
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
        }
        public class RegisterCommandResponse
        {
            public object IdentityResult { get; set; }
        }
        public class LoginCommand : IRequest<LoginCommandResponse>
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public bool RememberMe { get; set; }
        }
        public class LoginCommandResponse
        {
            public SignInResult SignInResult { get; set; }
        }
    }
}
