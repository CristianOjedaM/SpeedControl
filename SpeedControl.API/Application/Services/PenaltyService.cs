using SpeedControl.API.Domain;
using SpeedControl.API.Domain.Interfaces.Services;
using SpeedControl.API.Domain.Interfaces.Repository;
namespace SpeedControl.API.Application.Services
{
    public class PenaltyService : IPenaltyService
    {
        private readonly ICitiesRepository citiesRepository;
        private readonly List<Cities> cities = new List<Cities>();
        public PenaltyService(ICitiesRepository _citiesRepository)
        {
            citiesRepository = _citiesRepository;
            cities = citiesRepository.GetCities();
        }
        public Penaltys GetPenalties(Sensors sensor, string licensePlate)
        {
            if (licensePlate == string.Empty)
                throw new ArgumentNullException("License Plate Is Required");
            return CalculatePenalty(sensor);
        }

        public  ResponseBatch GetPenaltysBatches(List<SensorsBatch> sensors)
        {
            List<PenaltysBatch> penaltysBatches =  new List<PenaltysBatch>();
            sensors.ForEach(sensor =>
            {
                penaltysBatches.Add( new PenaltysBatch() { LicensePlate= sensor.LicensePlate , Info =  CalculatePenalty(sensor) });
            });
            var response = new ResponseBatch()
            {
                penaltysBatchValid = penaltysBatches.Where(n => n.Info.isValidPenalty == true),
                PenaltysBatchNotValid = penaltysBatches.Where(n => n.Info.isValidPenalty == false)
            };
            
            return response;
        }

        private Penaltys CalculatePenalty(Sensors sensor)
        {
            bool isPenaltyValid = false;
            Cities ciudadCercana = new Cities();
            Dictionary<Cities, double> distanceCityCerca = new Dictionary<Cities, double>();

            if (sensor.Velocity > 120 || sensor.Altitude > 50)            
                isPenaltyValid = true;            

            cities.ForEach(item => {
                var distanceCity = CalculateDistance(
                    item.Location.latitude,
                    item.Location.longitude,
                    sensor.Location.latitude,
                    sensor.Location.longitude);

                distanceCityCerca.Add(item, distanceCity);
            });

            ciudadCercana = distanceCityCerca.MinBy(n => n.Value).Key;
            var ticket = new Penaltys()
            {
                Distance = $"{distanceCityCerca.MinBy(n => n.Value).Value} mts",
                Penalty = isPenaltyValid ? "The Penalty Is Valid" : "The Ticket Is Not Valid",
                AssignedCity = ciudadCercana.Name,
                isValidPenalty = isPenaltyValid
            };

            return ticket;
        }

        private double CalculateDistance(int x1, int y1, int x2, int y2)
        {
            var distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            return Math.Round(distance,2);
        }
    }


}
