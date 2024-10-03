using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBooking.Business.Dtos.RequestDtos
{
    public class BookingCreateRequestDto
    {
        public Guid ShowId { get; set; }
        public string UserId { get; set; }
        public int SeatsBooked { get; set; }
    }
}
