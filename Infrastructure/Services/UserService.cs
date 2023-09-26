using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Identity;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class UserService : GenericRepository<Product>, IUserService
    {
        private EFDBContext db;
        public UserService(EFDBContext context) : base(context)
        {
            db = context;
        }

        public async Task<ApplicationUser> GetUserById(string userid)
        {
            var user = await db.Users.FirstOrDefaultAsync(i => i.Id == userid);
            return user;
        }
    }
}
