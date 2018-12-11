using Microsoft.AspNetCore.Mvc;
using ApiControllers.Models;
namespace ApiControllers.Controllers
{
    [Route("api/[controller]")]
    public class ContentController : Controller
    {
        [HttpGet("{str}")]
        public string GetString(string str) => $"This is a {str} response";

        //[HttpGet("object")]
        //[Produces("application/json")]

        [HttpGet("object/{format?}")]
        [FormatFilter]
        //[Produces("application/json", "application/xml")]
        public Reservation GetObject() => new Reservation
        {
            ReservationId = 100,
            ClientName = "Joe",
            Location = "Board Room"
        };


        [HttpPost]
        [Consumes("application/json")]
        public Reservation ReceiveJson([FromBody] Reservation reservation)
        {
            reservation.ClientName = "Json";
            return reservation;
        }

        [HttpPost]
        [Consumes("application/xml")]
        [Produces("application/xml")]
        public Reservation ReceiveXml([FromBody] Reservation reservation)
        {
            reservation.ClientName = "Xml";
            return reservation;
        }
    }
}