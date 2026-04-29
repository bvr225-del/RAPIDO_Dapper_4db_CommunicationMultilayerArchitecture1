using Dapper;
using Rapido_BusinessEntities.Dtos;
using Rapido_BusinessEntities.Interfaces;
using Rapido_BusinessEntities.Models;
using Rapido_BusinessEntities.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapido_Repositorylayer
{
    public class UserRepository : IUserRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public UserRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<UserSignInResponse> UserSignIn(UserSignIn urdetail)
        {
            using (IDbConnection con = _connectionFactory.HotelmanagementsqlConnectionString())
            {
                var p = new DynamicParameters();
                p.Add("@Username", urdetail.UserName);
                p.Add("@Password", urdetail.Password);
                //var queryResult = await conn.QueryAsync<Hotel>(StoredProcedureStaticMessages.GetHotelDetails, CommandType.StoredProcedure);
                var result = await con.QueryAsync<UserSignInResponse>(StoredprocedureNames.SignIn, p, commandType: CommandType.StoredProcedure);
                var status = result.FirstOrDefault();
                return status;

            }

        }

        public async Task<UserSignUpResponse> UserSignUp(UserSignUp urdetail)
        {
            using (IDbConnection con = _connectionFactory.HotelmanagementsqlConnectionString())
            {
                var p = new DynamicParameters();
                p.Add("@Username", urdetail.Username);
                p.Add("@Password", urdetail.Password);
                p.Add("@Email", urdetail.Email);
                p.Add("@FullName", urdetail.FullName);
                // var result = await con.ExecuteScalarAsync<UserSignUpResponse>(StoredProcedureStatusMessages.SignUp, p, commandType: CommandType.StoredProcedure);
                var result = await con.QueryAsync<UserSignUpResponse>(StoredprocedureNames.SignUp, p, commandType: CommandType.StoredProcedure);
                var status = result.FirstOrDefault();
                return status;

            }
        }
    }
}
