using Rapido_BusinessEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapido_BusinessEntities.Interfaces
{
    public interface IOrdersRepository
    {
        Task<List<Orders>> GetOrders();
        Task<Orders> GetOrderById(int orderid);
        Task<int> AddOrder(Orders orderdetail);
        Task<string> DeleteOrderById(int orderid);
        Task<string> UpdateOrder(Orders orderdetail);

    }
}
