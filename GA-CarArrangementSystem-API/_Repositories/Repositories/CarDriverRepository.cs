using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GA_CarArrangementSystem_API.Models;
using GA_CarArrangementSystem_API.Data;
using GA_CarArrangementSystem_API._Repositories.Repositories;
using GA_CarArrangementSystem_API._Repositories.Interface;

namespace GA_CarArrangementSystem_API._Repositories.Repositories
{
    public class CarDriverRepository : GeneralRepository<CarDriver>, ICarDriverRepository
    {
        private readonly DataContext dataContext;

        public CarDriverRepository(DataContext context) : base(context)
        {
            dataContext = context;
        }
    }
}
