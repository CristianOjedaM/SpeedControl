namespace SpeedControl.API.Domain.Interfaces.Services
{
    public interface IPenaltyService
    {
        Penaltys GetPenalties(Sensors sensors, string licensePlate);

        ResponseBatch GetPenaltysBatches(List<SensorsBatch> sensors);
    }
}
