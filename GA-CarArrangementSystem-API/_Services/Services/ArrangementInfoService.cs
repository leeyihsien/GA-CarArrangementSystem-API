using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GA_CarArrangementSystem_API._Services.Interface;
using GA_CarArrangementSystem_API._Repostories.Interface;
using GA_CarArrangementSystem_API.ViewModels;
using GA_CarArrangementSystem_API.Models;
using GA_CarArrangementSystem_API.Helpers;
using GA_CarArrangementSystem_API.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace GA_CarArrangementSystem_API._Services.Services
{
    public class ArrangementInfoService : IArrangementInfoService
    {

        private readonly IGeneralRepository generalRepository;
        private readonly IMapper mapper;
        private readonly MapperConfiguration mapperConfiguration;

        Task<bool> IGeneralService<ArrangementInfoDTO>.Add(ArrangementInfoDTO model)
        {
            throw new NotImplementedException();
        }

        Task<bool> IGeneralService<ArrangementInfoDTO>.Delete(object id)
        {
            throw new NotImplementedException();
        }

        Task<List<ArrangementInfoDTO>> IGeneralService<ArrangementInfoDTO>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        ArrangementInfoDTO IGeneralService<ArrangementInfoDTO>.GetById(object id)
        {
            throw new NotImplementedException();
        }

        Task<List<ArrangementInfoDTO>> IArrangementInfoService.GetID()
        {
            throw new NotImplementedException();
        }

        Task<bool> IGeneralService<ArrangementInfoDTO>.Update(ArrangementInfoDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
