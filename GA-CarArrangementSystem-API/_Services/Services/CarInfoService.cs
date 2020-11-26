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
    public class CarInfoService : ICarInfoService
    {
        private readonly ICarInfoRepository _carInfoRepository;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfiguration;


        public CarInfoService(ICarInfoRepository carInfoRepository, IMapper mapper, MapperConfiguration mapperConfiguration)
        {
            _carInfoRepository = carInfoRepository;
            _mapper = mapper;
            _mapperConfiguration = mapperConfiguration;
        }


        public async Task<bool> Add(CarInfoDTO model)
        {
            var item = _mapper.Map<CarInfo>(model);
            _carInfoRepository.Add(item);
            return await _carInfoRepository.SaveAll();
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(object id)
        {
            var item = _carInfoRepository.FindById(id);
            _carInfoRepository.Remove(item);
            return await _carInfoRepository.SaveAll();
            throw new NotImplementedException();
        }

        public async Task<List<CarInfoDTO>> GetAllAsync()
        {
            return await _carInfoRepository.FindAll().ProjectTo<CarInfoDTO>(_mapperConfiguration).OrderBy(x => x.CarId).ToListAsync();
        }

        public CarInfoDTO GetById(object id)
        {
            return _mapper.Map<CarInfo, CarInfoDTO>(_carInfoRepository.FindById(id));
            throw new NotImplementedException();
        }

        public async Task<bool> Update(CarInfoDTO model)
        {
            var item = _mapper.Map<CarInfo>(model);
            item.UpdateAt = DateTime.Now;
            _carInfoRepository.Update(item);
            return await _carInfoRepository.SaveAll();
            throw new NotImplementedException();
        }
    }
}
