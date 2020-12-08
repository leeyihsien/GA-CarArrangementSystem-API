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
using Microsoft.Data.SqlClient;
using System.Data;

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
            item.CreateAt = DateTime.Now;
            item.ArrangementId = GetMaxSerialNo();
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


        public async Task<bool> Update(ArrangementInfoDTO model)
        {

            var item = _mapper.Map<ArrangementInfo>(model);
            item.UpdateAt = DateTime.Now;
            _arrangementInfoRepository.Update(item);
            return await _arrangementInfoRepository.SaveAll();

            throw new NotImplementedException();
        }

        public ArrangementInfoDTO GetById(object id)
        {
            return _mapper.Map<ArrangementInfo, ArrangementInfoDTO>(_arrangementInfoRepository.FindById(id));
            throw new NotImplementedException();
        }



        //流水號生成
        public string GetMaxSerialNo()
        {
            SqlConnection sqlConnection = new SqlConnection("Server=10.4.0.34;Database=GA_Test;MultipleActiveResultSets=true;User Id=sa;Password=shc@123");
            SqlCommand sqlCommand = new SqlCommand("Select Max(arrangementId)  FROM ArrangementInfo", sqlConnection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dtSerialNo = new DataTable();
            dataAdapter.Fill(dtSerialNo);
            string date = DateTime.Now.ToString("yyyy" + "MM");
            string str = dtSerialNo.Rows[0][0].ToString();


                string maxDate = str.Substring(2, 6);//得到订单编号最大值的“年月”部分(201906)
                string maxDateNo = str.Substring(8, 4);//得到订单编号最大值的序列部分，也就是“-”之后的三个数字（002）
                if (date == maxDate)//如果本月有数据
                {
                    int.TryParse(maxDateNo, out int dd);//将订单编号的序列部分转换为 int 类型，以便进行“+1”运算
                    int newDateNo = dd + 1;
                    str = "AR" + date + newDateNo.ToString("0000");
                }
                else
                {
                    str = "AR" + date + "0001";// “-”和 “001” 分开写会更清晰些
                }

           
           


            return str;

        }

        

       }
    }
