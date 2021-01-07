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
    public class RouteScheduleService : IRouteScheduleService
    {
        private readonly IRouteScheduleRepository _routeScheduleRepository;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfiguration;

        public RouteScheduleService(IRouteScheduleRepository routeScheduleRepository, IMapper mapper, MapperConfiguration mapperConfiguration)
        {
            _routeScheduleRepository = routeScheduleRepository;
            _mapper = mapper;
            _mapperConfiguration = mapperConfiguration;
        }

        public async Task<bool> Add(RouteScheduleDTO model)
        {
            var item = _mapper.Map<RouteSchedule>(model);
            _routeScheduleRepository.Add(item);
            item.CreateAt = DateTime.Now;
            return await _routeScheduleRepository.SaveAll();
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(object id)
        {
            var item = _routeScheduleRepository.FindById(id);
            _routeScheduleRepository.Remove(item);
            return await _routeScheduleRepository.SaveAll();
            throw new NotImplementedException();
        }

        public async Task<List<RouteScheduleDTO>> GetAllAsync()
        {
            return await _routeScheduleRepository.FindAll().ProjectTo<RouteScheduleDTO>(_mapperConfiguration).OrderBy(x => x.EventId).ToListAsync();
            throw new NotImplementedException();
        }

        public RouteScheduleDTO GetById(object id)
        {
            return _mapper.Map<RouteSchedule, RouteScheduleDTO>(_routeScheduleRepository.FindById(id));
            throw new NotImplementedException();
        }

        public async Task<bool> Update(RouteScheduleDTO model)
        {
            var item = _mapper.Map<RouteSchedule>(model);
            item.UpdateAt = DateTime.Now;
            _routeScheduleRepository.Update(item);
            return await _routeScheduleRepository.SaveAll();
            throw new NotImplementedException();
        }
    }
}
