using AutoMapper;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.Account.AccountCommands.AccountCommands;

namespace Application.Features.Account.AccountQueries
{
    public class AccountQueriesResponse :
        IRequestHandler<GetUserById, GetUserByIdResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccountQueriesResponse(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<GetUserByIdResponse> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            var user = _userService.GetUserById(request.UserId);
            return new() { User = user };
        }
    }
}
