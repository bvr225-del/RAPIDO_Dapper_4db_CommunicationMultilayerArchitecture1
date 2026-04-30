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
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;
        public OrdersService(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            this._mapper = mapper;
        }
        public async Task<int> AddOrder(OrdersDto orderdetail)
        {
            Orders order = new Orders();
            _mapper.Map(orderdetail, order);

            //order.orderid = orderdetail.orderid;
            if (orderdetail?.Flag == "Hyderabad")//Here Flag is used to apply the conditions.based on condition we are perming the opertions.
            {
                order.ordername = orderdetail.ordername + '-' + orderdetail.orderlocation;
            }
            else
            {//if you are not using the flag then you can directly assign the value to ordername without any condition as shown below.
                order.ordername = orderdetail.ordername;
            }

            //order.orderlocation = orderdetail.orderlocation;
            //to pass the data to repository we are not pass the falg value,falg is used to check the condition purpose only
            var res = await _ordersRepository.AddOrder(order);
            return res;

        }

        public async Task<string> DeleteOrderById(int orderid)
        {
            var res = await _ordersRepository.DeleteOrderById(orderid);
            return res;

        }

        public async Task<OrdersDto> GetOrderById(int orderid)
        {
            var res = await _ordersRepository.GetOrderById(orderid);
            return _mapper.Map<OrdersDto>(res);

        }

        public async Task<List<OrdersDto>> GetOrders()
        {
            List<OrdersDto> lstorderdto = new List<OrdersDto>();
            var res = await _ordersRepository.GetOrders();
            return _mapper.Map<List<OrdersDto>>(res);
        }

        public async Task<string> UpdateOrder(OrdersDto orderdetail)
        {
            Orders obj = new Orders();
            _mapper.Map(orderdetail, obj);
            var res = await _ordersRepository.UpdateOrder(obj);
            return res;

        }
    }
}
