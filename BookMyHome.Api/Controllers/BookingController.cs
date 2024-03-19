using System.Runtime.InteropServices;
using BookMyHome.Application.Queries.Booking;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookMyHome.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingQuery _bookingQuery;

        public BookingController(IBookingQuery bookingQuery)
        {
            _bookingQuery = bookingQuery;
        }
        // GET: api/<BookingController>
        [HttpGet("ByAccomodation/{accomodationId}")]
        public IEnumerable<BookingDto> Get(Guid accomodationId)
        {
            return _bookingQuery.GetBookingsByAccommodationId(accomodationId);
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BookingController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
