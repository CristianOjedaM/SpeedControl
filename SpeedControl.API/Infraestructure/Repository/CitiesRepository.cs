using SpeedControl.API.Domain;
using SpeedControl.API.Domain.Interfaces.Repository;

namespace SpeedControl.API.Infraestructure.Repository
{
    public class CitiesRepository : ICitiesRepository
    {
        public CitiesRepository()
        {

        }
        public List<Cities> GetCities()
        {
            List<Cities> cities = new List<Cities>()
            {
                new Cities()
                {                   
                    Name = "North City",
                    Location = new Coordinate(){ latitude = -500, longitude = -200}
                },
                new Cities()
                {                   
                    Name = "South City",
                    Location = new Coordinate(){ latitude = 100, longitude = -100}
                },
                new Cities()
                {                    
                    Name = "East City",
                    Location = new Coordinate(){ latitude = 500, longitude = 100}
                },
                new Cities()
                {                    
                     Name = "West City",
                     Location = new Coordinate(){ latitude = 200, longitude = 100}
                }
            };

            return cities;
        }
    }
}
