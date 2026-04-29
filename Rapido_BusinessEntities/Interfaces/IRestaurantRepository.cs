using Rapido_BusinessEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapido_BusinessEntities.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<List<Restaurant>> GetRestaurants();
        Task<Restaurant> GetRestaurantById(int restaurantid);
        Task<int> AddRestaurant(Restaurant restaurantdetail);
        Task<string> DeleteRestaurantById(int restaurantid);
        Task<string> UpdateRestaurant(Restaurant restaurantdetail);

    }
}
