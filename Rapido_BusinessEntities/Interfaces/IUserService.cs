using Rapido_BusinessEntities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapido_BusinessEntities.Interfaces
{
    public interface IUserService
    {
        Task<UserSignInResponse> UserSignIn(UserSignInDto userDetailDto);
        Task<UserSignUpResponse> UserSignUp(UserSignUpDto userDetailDto);

    }
}
