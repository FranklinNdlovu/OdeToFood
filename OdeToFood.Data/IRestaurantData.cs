using OdeToFood.Core;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetResturantsByName(string name);
        Restaurant GetRestaurantById(int restaurantId);

        Restaurant UpdateRestaurant(Restaurant updatedRestaurant);

        Restaurant AddRestaurant(Restaurant newRestaurant);
        int Commit();
    }
}
