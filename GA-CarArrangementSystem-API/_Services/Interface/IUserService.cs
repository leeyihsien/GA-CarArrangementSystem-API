using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GA_CarArrangementSystem_API.DTO;
using GA_CarArrangementSystem_API.Models;

namespace GA_CarArrangementSystem_API._Services.Interface
{
    public interface IUserService
    {
    
        Task<UserAccDTO> GetUser(object id);
        Task<UserAcc> Login(string account, string password);

        Task<List<UserAccDTO>> GetAll();

    }
}
