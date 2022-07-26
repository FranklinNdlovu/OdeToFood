using OdeToFood.Core;
using System.Linq;
using System.Collections.Generic;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id =1, Name="Cheesecake factory", Location="America", Cuisine=CuisineType.American},
                new Restaurant{Id =2, Name="La Strada", Location="Italy", Cuisine=CuisineType.Italian},
                new Restaurant{Id =3, Name="Bistro Maxine", Location="France", Cuisine=CuisineType.Mexican}
            };
        }

        public Restaurant GetRestaurantById(int restaurantId)
        {
            return restaurants.FirstOrDefault(r => r.Id == restaurantId);
        }

        public IEnumerable<Restaurant> GetResturantsByName(string name =null)
        {
            return from r in restaurants 
                   orderby r.Name
                   where string.IsNullOrEmpty(name) || r.Name.ToLower().Contains(name.ToLower())
                   select r;
        }

        public Restaurant UpdateRestaurant(Restaurant updatedRestaurant)
        {
            Restaurant restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant AddRestaurant(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }
    }
}
