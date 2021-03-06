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
    public class CarInfoRepository : GeneralRepository<CarInfo>, ICarInfoRepository
    {
        private readonly DataContext dataContext;

        public CarInfoRepository(DataContext context) : base(context)
        {
            dataContext = context;
        }
    }
}
