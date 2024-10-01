using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBooking.Business.Dtos.ResponseDtos
{
    public class ShowResponseDto
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int ScreenNo { get; set; }
        public int NoOfSeats { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
