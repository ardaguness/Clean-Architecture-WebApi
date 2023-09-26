using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Account.AccountQueries
{
    public class GetUserById:IRequest<GetUserByIdResponse>
    {
        public string UserId { get; set; }
    }
    public class GetUserByIdResponse
    {
        public object User { get; set; }
    }
}
