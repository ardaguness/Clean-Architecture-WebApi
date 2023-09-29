using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUserById(string userid);
        Task<ICollection<ApplicationUser>> GetAllUsersAsync();
    }
}
