using Rapido_BusinessEntities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapido_BusinessEntities.Interfaces
{
    public interface IOrdersService
    {
        Task<List<OrdersDto>> GetOrders();
        Task<OrdersDto> GetOrderById(int orderid);
        Task<int> AddOrder(OrdersDto orderdetail);
        Task<string> DeleteOrderById(int orderid);
        Task<string> UpdateOrder(OrdersDto orderdetail);

    }
}
