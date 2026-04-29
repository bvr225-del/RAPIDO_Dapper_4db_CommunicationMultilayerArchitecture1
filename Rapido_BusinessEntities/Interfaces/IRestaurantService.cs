using Rapido_BusinessEntities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapido_BusinessEntities.Interfaces
{
    public interface IRestaurantService
    {
        Task<List<RestaurantDto>> GetRestaurants();
        Task<RestaurantDto> GetRestaurantById(int restaurantid);
        Task<int> AddRestaurant(RestaurantDto restaurantdetail);
        Task<string> DeleteRestaurantById(int restaurantid);
        Task<string> UpdateRestaurant(RestaurantDto restaurantdetail);

    }
}
