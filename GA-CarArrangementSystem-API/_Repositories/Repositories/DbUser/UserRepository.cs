﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GA_CarArrangementSystem_API.Models;
using GA_CarArrangementSystem_API.Data;
using GA_CarArrangementSystem_API._Repositories.Interface.DbUser;

namespace GA_CarArrangementSystem_API._Repositories.Repositories.DbUser
{
    public class UserRepository : DbUserRepository<UserAcc>, IUserRepository
    {
        public UserRepository(UserContext context) : base(context)
        {
        }
    }
}
