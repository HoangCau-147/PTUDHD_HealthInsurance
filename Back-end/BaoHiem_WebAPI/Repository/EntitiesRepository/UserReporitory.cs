using Contracts;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntitiesRepository
{
    public sealed class UserReporitory : IUserRepository
    {
        private readonly InsuranceDBContext _dBContext;
        public UserReporitory(InsuranceDBContext insuranceDBContext) 
        {
            _dBContext = insuranceDBContext;
        }
        public bool Add(User user)
        {
            var result = _dBContext.Users.Add(user);
            if(result.State == EntityState.Added)
            {
                return true;
            }
            return false;
        }
    }
}
