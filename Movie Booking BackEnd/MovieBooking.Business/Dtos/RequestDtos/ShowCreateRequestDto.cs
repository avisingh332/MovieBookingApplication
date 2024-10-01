using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBooking.Business.Dtos.RequestDtos
{
    public class ShowCreateRequestDto
    {
        public Guid MovieId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int ScreenNo { get; set; }
        public int NoOfSeats { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
