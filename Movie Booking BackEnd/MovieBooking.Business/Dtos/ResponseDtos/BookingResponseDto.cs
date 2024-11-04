using MovieBooking.Business.Dtos.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBooking.Business.Dtos.RequestDtos
{
    public class BookingResponseDto
    {
        public Guid Id { get; set; }
        public Guid ShowId { get; set; }
        public string UserId { get; set; }
        public int SeatsBooked { get; set; }
        public DateOnly BookingDate { get; set; }
        public ShowResponseDto? ShowDetails { get; set; }
        public MovieGetResponseDto? MovieDetails { get; set; }

    }
}
