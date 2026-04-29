using Rapido_BusinessEntities.Dtos;
using Rapido_BusinessEntities.Interfaces;
using Rapido_BusinessEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapido_ServiceLayer
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserSignInResponse> UserSignIn(UserSignInDto userDetailDto)
        {
            UserSignIn usi = new UserSignIn();
            usi.UserName = userDetailDto.UserName;
            usi.Password = userDetailDto.Password;
            var res = await _userRepository.UserSignIn(usi);
            return res;
        }

        public async Task<UserSignUpResponse> UserSignUp(UserSignUpDto userDetailDto)
        {
            UserSignUp usi = new UserSignUp();
            usi.FullName = userDetailDto.FullName;
            usi.Username = userDetailDto.Username;
            usi.Email = userDetailDto.Email;
            usi.Password = userDetailDto.Password;
            var res = await _userRepository.UserSignUp(usi);
            return res;
        }
    }
}
