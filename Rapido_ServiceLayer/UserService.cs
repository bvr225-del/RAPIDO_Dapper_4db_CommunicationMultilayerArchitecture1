using AutoMapper;
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
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            this._mapper = mapper;
        }
        public async Task<UserSignInResponse> UserSignIn(UserSignInDto userDetailDto)
        {
            UserSignIn usi = new UserSignIn();
            _mapper.Map(userDetailDto, usi);

            var res = await _userRepository.UserSignIn(usi);
            return res;
        }

        public async Task<UserSignUpResponse> UserSignUp(UserSignUpDto userDetailDto)
        {
            UserSignUp usi = new UserSignUp();
            _mapper.Map(userDetailDto, usi);
            var res = await _userRepository.UserSignUp(usi);
            return res;
        }
    }
}
