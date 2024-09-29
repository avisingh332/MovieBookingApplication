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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ScreenNo { get; set; }
        public int NoOfSeats { get; set; }
    }
}
