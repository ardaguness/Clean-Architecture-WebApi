using AutoMapper;
using Domain.Entities.Identity;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.Account.AccountCommands.AccountCommands;

namespace Application.Features.Account.AccountCommands
{
    public class AccountCommandHandlers :
        IRequestHandler<RegisterCommand, RegisterCommandResponse>,
        IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AccountCommandHandlers(IAuthService productRepo, IMapper mapper)
        {
            _authService = productRepo;
            _mapper = mapper;
        }

        public async Task<RegisterCommandResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var userRegister = _mapper.Map<RegisterUser>(request);

            var identityResult = await _authService.RegisterAsync(userRegister);

            return new RegisterCommandResponse
            {
                IdentityResult = identityResult
            };
        }

        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.LoginAsync(request.Username, request.Password, request.RememberMe);

            return new LoginCommandResponse
            {
                SignInResult = result
            };
        }
    }
}
