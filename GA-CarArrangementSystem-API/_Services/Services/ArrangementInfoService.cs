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

/// <summary>
/// 實作服務介面
/// 透過repository 針對資料庫進行修改
/// mapper 實現 model 和 DTO 之間的轉換
/// </summary>

namespace GA_CarArrangementSystem_API._Services.Services
{
    public class ArrangementInfoService : IArrangementInfoService
    {

        private readonly IArrangementInfoRepository _arrangementInfoRepository;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfiguration;

        public ArrangementInfoService(IArrangementInfoRepository arrangementInfoRepository, IMapper mapper, MapperConfiguration mapperConfiguration)
        {
            _mapperConfiguration = mapperConfiguration;
            _mapper = mapper;
            _arrangementInfoRepository = arrangementInfoRepository;
            
            
        }

        public async Task<bool> Add(ArrangementInfoDTO model)
        {
            var item = _mapper.Map<ArrangementInfo>(model);
            _arrangementInfoRepository.Add(item);
            return await _arrangementInfoRepository.SaveAll();
        }

        public async Task<bool> Delete(object id)
        {
            var item = _arrangementInfoRepository.FindById(id);
            _arrangementInfoRepository.Remove(item);
            return await _arrangementInfoRepository.SaveAll();
        }


        /// <summary>
        /// 取得全部並按照 ArrangementDate 從大到小排序
        /// </summary>
        /// <returns></returns>
        public async Task<List<ArrangementInfoDTO>> GetAllAsync()
        {
            return await _arrangementInfoRepository.FindAll().ProjectTo<ArrangementInfoDTO>(_mapperConfiguration).OrderBy(x => x.ArrangementId).ToListAsync();
        }

        //public async Task<List<ArrangementInfoDTO>> GetArrangeDate()
        //{
        //    return await _arrangementInfoRepository.FindAll().ProjectTo<ArrangementInfoDTO>(_mapperConfiguration).OrderByDescending(x => x.ArrangeDate).ToListAsync();

        //}

        //public async Task<List<ArrangementInfoDTO>> GetBackTime()
        //{
        //    return await _arrangementInfoRepository.FindAll().ProjectTo<ArrangementInfoDTO>(_mapperConfiguration).OrderByDescending(x => x.ArrangeDate).ToListAsync();

        //}


        /// <summary>
        /// 使用ID來獲取資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ArrangementInfoDTO GetById(object id)
        {
            return _mapper.Map<ArrangementInfo, ArrangementInfoDTO>(_arrangementInfoRepository.FindById(id));
           // throw new NotImplementedException();
        }

        //public async Task<List<ArrangementInfoDTO>> GetGoTime()
        //{
        //    return await _arrangementInfoRepository.FindAll().ProjectTo<ArrangementInfoDTO>(_mapperConfiguration).OrderByDescending(x => x.ArrangeDate).ToListAsync();

        //    //throw new NotImplementedException();
        //}

        //public async Task<List<ArrangementInfoDTO>> GetID()
        //{
        //    return await _arrangementInfoRepository.FindAll().ProjectTo<ArrangementInfoDTO>(_mapperConfiguration).OrderByDescending(x => x.ArrangeDate).ToListAsync();

        //    //throw new NotImplementedException();
        //}

        //public async Task<List<ArrangementInfoDTO>> GetRouteId()
        //{
        //    return await _arrangementInfoRepository.FindAll().ProjectTo<ArrangementInfoDTO>(_mapperConfiguration).OrderByDescending(x => x.ArrangeDate).ToListAsync();

        //    // throw new NotImplementedException();
        //}

        //public async Task<List<ArrangementInfoDTO>> GetStatus()
        //{
        //    return await _arrangementInfoRepository.FindAll().ProjectTo<ArrangementInfoDTO>(_mapperConfiguration).OrderByDescending(x => x.ArrangeDate).ToListAsync();

        //    // throw new NotImplementedException();
        //}

        //public async Task<List<ArrangementInfoDTO>> GetUserId()
        //{
        //    return await _arrangementInfoRepository.FindAll().ProjectTo<ArrangementInfoDTO>(_mapperConfiguration).OrderByDescending(x => x.ArrangeDate).ToListAsync();

        //    // throw new NotImplementedException();
        //}

        public async Task<bool> Update(ArrangementInfoDTO model)
        {

            var item = _mapper.Map<ArrangementInfo>(model);
            item.UpdateAt = DateTime.Now;
            _arrangementInfoRepository.Update(item);
            return await _arrangementInfoRepository.SaveAll();

            throw new NotImplementedException();
        }
    }
}
