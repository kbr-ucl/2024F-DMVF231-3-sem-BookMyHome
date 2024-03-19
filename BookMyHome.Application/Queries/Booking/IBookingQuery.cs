using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Queries.Booking
{
    public interface IBookingQuery
    {
        IEnumerable<BookingDto> GetBookingsByAccommodationId(Guid accommodationId);
        IEnumerable<BookingDto> GetBookingsByUserId(Guid userId);
        BookingDto GetBookingById(Guid id);
    }
}
