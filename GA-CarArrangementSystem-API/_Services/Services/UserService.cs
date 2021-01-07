using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GA_CarArrangementSystem_API._Services.Interface;
using GA_CarArrangementSystem_API._Repositories.Interface;
using GA_CarArrangementSystem_API._Repositories.Interface.DbUser;
using GA_CarArrangementSystem_API.Models;
using GA_CarArrangementSystem_API.Helpers.AutoMapper;
using GA_CarArrangementSystem_API.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace GA_CarArrangementSystem_API._Services.Services
{
    public class UserService : IUserService
    {
        private readonly MapperConfiguration _mapperConfiguration;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(MapperConfiguration mapperConfiguration, IConfiguration configuration, IMapper mapper, IUserRepository userRepository)
        {
            _configuration = configuration;
            _mapperConfiguration = mapperConfiguration;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public Task<List<UserAccDTO>> GetAll()
        {
            return _userRepository.FindAll().ProjectTo<UserAccDTO>(_mapperConfiguration).OrderBy(x => x.id).ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<UserAccDTO> GetUser(object id)
        {
            return _mapper.Map<UserAcc, UserAccDTO>(_userRepository.FindById(id));
            throw new NotImplementedException();
        }

        public async Task<UserAcc> Login(string account, string password)
        {
            var user = _userRepository.FindSingle(x => x.account.Trim() == account.Trim() && x.passw.Trim() == password.Trim());

            if (user == null)
            {
                return null;
            }

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var claims = new[]
             {
                    new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
                    new Claim(ClaimTypes.Name, user.account)
             };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.token = tokenHandler.WriteToken(token);


            return user;


            throw new NotImplementedException();
        }

   
    }
}
