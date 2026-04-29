using Rapido_BusinessEntities.Dtos;
using Rapido_BusinessEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapido_BusinessEntities.Interfaces
{
    public interface IUserRepository
    {
        Task<UserSignInResponse> UserSignIn(UserSignIn urdetail);
        Task<UserSignUpResponse> UserSignUp(UserSignUp urdetail);

    }
}
