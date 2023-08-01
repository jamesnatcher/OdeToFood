using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant? GetById(int id);
    }
    public class InMemomeryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants { get; }
        public InMemomeryRestaurantData()
        {
            restaurants = new List<Restaurant>()
                {
                    new Restaurant {
                        Id = 1,
                        Name = "Scott's Pizza",
                        Location = "Maryland",
                        Cuisine = CuisingType.Italian,
                        },
                    new Restaurant {
                        Id = 2,
                        Name = "Pendejo Bros",
                        Location = "Denver",
                        Cuisine = CuisingType.Mexican,
                        },
                    new Restaurant {
                        Id = 2,
                        Name = "Himalaya Place",
                        Location = "Maryland",
                        Cuisine = CuisingType.Indian,
                        },
                    new Restaurant {
                        Id = 3,
                        Name = "Fusion Pusion",
                        Location = "New York",
                        Cuisine = CuisingType.None,
                        }
                };


        }
        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }


        public IEnumerable<Restaurant> GetRestaurantsByName(string? name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.ToUpper().StartsWith(name.ToUpper())
                   orderby r.Name
                   select r;
        }
    }
}
