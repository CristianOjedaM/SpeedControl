using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpeedControl.API.Domain;
using SpeedControl.API.Domain.Interfaces.Services;

namespace SpeedControl.API.Controllers
{
    [Route("api/Multas")]
    [ApiController]
    public class SpeedControlController : ControllerBase
    {
        private IPenaltyService penaltyService;
        public SpeedControlController(IPenaltyService _penaltyService)
        {
            penaltyService = _penaltyService;
        }

        [HttpGet("Health")]
        public ActionResult Health()
        {
            return Ok("Estoy Arriba");
        }


        [HttpPost("LevantarMulta")]
        public ActionResult<Penaltys> Penalty([FromBody]Sensors sensors, [FromQuery(Name ="matricula")] string licensePlate)
        {
            Penaltys penaltys = penaltyService.GetPenalties(sensors, licensePlate);
            return Ok(penaltys);
        }

        [HttpPost("LevantarMultas")]
        public ActionResult<ResponseBatch> PenaltysBatch([FromBody] List<SensorsBatch> sensors)
        {
            ResponseBatch penaltys = penaltyService.GetPenaltysBatches(sensors);            
            return Ok(penaltys);
        }
       

    }
}
