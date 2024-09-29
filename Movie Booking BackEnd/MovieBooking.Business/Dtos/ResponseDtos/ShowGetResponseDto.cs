using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBooking.Business.Dtos.ResponseDtos
{
    public class ShowGetResponseDto
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int ScreenNo { get; set; }
        public int NoOfSeats { get; set; }
        public TimeOnly ShowTiming { get; set; }
    }
}
