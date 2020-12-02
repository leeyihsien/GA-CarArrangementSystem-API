using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GA_CarArrangementSystem_API._Services.Interface;
using GA_CarArrangementSystem_API._Repositories.Interface;
using GA_CarArrangementSystem_API.ViewModels;
using GA_CarArrangementSystem_API.Models;
using GA_CarArrangementSystem_API.Helpers.AutoMapper;
using GA_CarArrangementSystem_API.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace GA_CarArrangementSystem_API._Services.Services
{
    public class RouteInfoService : IRouteInfoService
    {
        private readonly IRouteInfoRepository _routeInfoRepository;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfiguration;

        public RouteInfoService(IRouteInfoRepository routeInfoRepository, IMapper mapper, MapperConfiguration mapperConfiguration)
        {
            _routeInfoRepository = routeInfoRepository;
            _mapper = mapper;
            _mapperConfiguration = mapperConfiguration;
        }

        public async  Task<bool> Add(RouteInfoDTO model)
        {
            var item = _mapper.Map<RouteInfo>(model);
            _routeInfoRepository.Add(item);
            item.CreateAt = DateTime.Now;
            return await _routeInfoRepository.SaveAll();
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(object id)
        {
            var item = _routeInfoRepository.FindById(id);
            _routeInfoRepository.Remove(item);
            return await _routeInfoRepository.SaveAll();
            throw new NotImplementedException();
        }

        public async Task<List<RouteInfoDTO>> GetAllAsync()
        {
            return await _routeInfoRepository.FindAll().ProjectTo<RouteInfoDTO>(_mapperConfiguration).OrderBy(x => x.RouteId).ToListAsync();
            throw new NotImplementedException();
        }

        public RouteInfoDTO GetById(object id)
        {
            return _mapper.Map<RouteInfo, RouteInfoDTO>(_routeInfoRepository.FindById(id));
            throw new NotImplementedException();
        }

        public async Task<bool> Update(RouteInfoDTO model)
        {
            var item = _mapper.Map<RouteInfo>(model);
            item.UpdateAt = DateTime.Now;
            _routeInfoRepository.Update(item);
            return await _routeInfoRepository.SaveAll();
            throw new NotImplementedException();
        }
    }
}
