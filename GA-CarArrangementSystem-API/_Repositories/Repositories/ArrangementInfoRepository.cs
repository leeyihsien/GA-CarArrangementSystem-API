﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GA_CarArrangementSystem_API.Models;
using GA_CarArrangementSystem_API.Data;
using GA_CarArrangementSystem_API._Repositories.Repositories;
using GA_CarArrangementSystem_API._Repositories.Interface;

namespace GA_CarArrangementSystem_API._Repositories.Repositories
{
    public class ArrangementInfoRepository : GeneralRepository<ArrangementInfo>, IArrangementInfoRepository
    {
        private readonly DataContext dataContext;

        public ArrangementInfoRepository(DataContext context) : base(context)
        {
            dataContext = context;
        }
    }
}
