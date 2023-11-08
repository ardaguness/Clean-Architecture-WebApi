using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.SignalR.HubServices
{
    public interface IProductHubService
    {
        Task ProductAddedMessageAsync(string message);
        Task ProductUpdatedMessageAsync(string message);
        Task ProductRemovedMessageAsync(string message);
    }
}
