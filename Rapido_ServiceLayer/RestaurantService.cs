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
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;
        public RestaurantService(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            this._mapper = mapper;
        }
        public async Task<int> AddRestaurant(RestaurantDto restaurantdetail)
        {
            Restaurant restaurant = new Restaurant();
            _mapper.Map(restaurantdetail, restaurant);

            if (restaurantdetail?.Flag == "Vizag")//Here Flag is used to apply the conditions.based on condition we are perming the opertions.
            {
                restaurant.RestaurantName = restaurantdetail.RestaurantName + '-' + restaurantdetail.RestaurantLocation;
            }
            else
            {//if you are not using the flag then you can directly assign the value to ordername without any condition as shown below.
                restaurant.RestaurantName = restaurantdetail.RestaurantName;
            }

            //to pass the data to repository we are not pass the falg value,falg is used to check the condition purpose only
            var res = await _restaurantRepository.AddRestaurant(restaurant);
            return res;


        }

        public async Task<string> DeleteRestaurantById(int restaurantid)
        {
            var res = await _restaurantRepository.DeleteRestaurantById(restaurantid);
            return res;

        }

        public async Task<RestaurantDto> GetRestaurantById(int restaurantid)
        {
            var res = await _restaurantRepository.GetRestaurantById(restaurantid);
            return _mapper.Map<RestaurantDto>(res);

        }

        public async Task<List<RestaurantDto>> GetRestaurants()
        {
            var res = await _restaurantRepository.GetRestaurants();
            return _mapper.Map<List<RestaurantDto>>(res);
        }

        public async Task<string> UpdateRestaurant(RestaurantDto restaurantdetail)
        {
            Restaurant obj = new Restaurant();
            _mapper.Map(restaurantdetail, obj);
            var res = await _restaurantRepository.UpdateRestaurant(obj);
            return res;

        }
    }
}
