using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Rapido_BusinessEntities.Interfaces;
using Rapido_BusinessEntities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapido_DbConnectivity
{
    public class ConnectionFactory : IConnectionFactory
    {
        /*
iF YOU WANT READ THE CONNECTION STRING FROM APPSETTINGS.JSON FILE,
WE HAVE ONE PREDEFINE INTEFACE IS AVAILABLE IN .NET CALLED IConfiguration, 
WE CAN INJECT IT IN THE CONSTRUCTOR OF THE CONNECTION FACTORY CLASS AND THEN READ THE CONNECTION STRING FROM APPSETTINGS.JSON FILE.
*/
        private readonly IConfiguration _configuration;
        //inject the IConfiguration interface in the constructor of the connection factory class and assign it to the private readonly field of the IConfiguration interface type.
        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public SqlConnection HotelmanagementsqlConnectionString()
        {
            var connectionString = Convert.ToString(_configuration.GetSection(ConnectionStringNames.Hotelmanagement_DBConnectionstringname).Value);
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }

        public SqlConnection MidLandSqlConnectionString()
        {
            var connectionString = Convert.ToString(_configuration.GetSection(ConnectionStringNames.Midland_DBConnectionstringname).Value);
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }

        public SqlConnection Northwind_DBSqlConnectionString()
        {
            var connectionString = Convert.ToString(_configuration.GetSection(ConnectionStringNames.Northwind_DBConnectionstringname).Value);
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }

        public SqlConnection RestaurantDBSqlConnectionString()
        {
            var connectionString = Convert.ToString(_configuration.GetSection(ConnectionStringNames.Restaurant_DBConnectionstringname).Value);
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }
    }
}
