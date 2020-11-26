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
    public class DriverInfoService : IDriverInfoService
    {
        private readonly IDriverInfoRepository _driverInfoRepository;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfiguration;

        public DriverInfoService(IDriverInfoRepository driverInfoRepository, IMapper mapper, MapperConfiguration mapperConfiguration)
        {
            _driverInfoRepository = driverInfoRepository;
            _mapper = mapper;
            _mapperConfiguration = mapperConfiguration;

        }
            
        public async Task<bool> Add(DriverInfoDTO model)
        {
            var item = _mapper.Map<DriverInfo>(model);
            _driverInfoRepository.Add(item);
            return await _driverInfoRepository.SaveAll();

            throw new NotImplementedException();
        }

        public async Task<bool> Delete(object id)
        {
            var item = _driverInfoRepository.FindById(id);
            _driverInfoRepository.Remove(item);
            return await _driverInfoRepository.SaveAll();
            throw new NotImplementedException();
        }

        public async Task<List<DriverInfoDTO>> GetAllAsync()
        {
            return await _driverInfoRepository.FindAll().ProjectTo<DriverInfoDTO>(_mapperConfiguration).OrderBy(x => x.DriverId).ToListAsync();
            throw new NotImplementedException();
        }

        public DriverInfoDTO GetById(object id)
        {
            return _mapper.Map<DriverInfo, DriverInfoDTO>(_driverInfoRepository.FindById(id));
            throw new NotImplementedException();
        }

        public async Task<bool> Update(DriverInfoDTO model)
        {
            var item = _mapper.Map<DriverInfo>(model);
            item.UpdateAt = DateTime.Now;
            return await _driverInfoRepository.SaveAll();
            throw new NotImplementedException();
        }
    }
}
