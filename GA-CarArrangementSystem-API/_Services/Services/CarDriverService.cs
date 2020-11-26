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

    public class CarDriverService : ICarDriverService
    {
        private readonly ICarDriverRepository _carDriverRepository;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfiguration;



        public CarDriverService(ICarDriverRepository carDriverRepository, IMapper mapper, MapperConfiguration mapperConfiguration)
        {
            _carDriverRepository = carDriverRepository;
            _mapper = mapper;
            _mapperConfiguration = mapperConfiguration;
        }


        public async Task<bool> Add(CarDriverDTO model)
        {
            var item = _mapper.Map<CarDriver>(model);
            _carDriverRepository.Add(item);
            return await _carDriverRepository.SaveAll();
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(object id)
        {
            var item = _carDriverRepository.FindById(id);
            _carDriverRepository.Remove(item);
            return await _carDriverRepository.SaveAll();
            throw new NotImplementedException();
        }

        public async Task<List<CarDriverDTO>> GetAllAsync()
        {
            return await _carDriverRepository.FindAll().ProjectTo<CarDriverDTO>(_mapperConfiguration).OrderByDescending( x => x.Id ).ToListAsync();
        //    throw new NotImplementedException();
        }

        public CarDriverDTO GetById(object id)
        {
            return _mapper.Map<CarDriver, CarDriverDTO>(_carDriverRepository.FindById(id));
            //throw new NotImplementedException();
        }

        public Task<bool> Update(CarDriverDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
