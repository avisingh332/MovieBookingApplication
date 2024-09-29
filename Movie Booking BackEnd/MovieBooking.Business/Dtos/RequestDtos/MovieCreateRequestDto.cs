using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBooking.Business.Dtos.RequestDtos
{
    public class MovieCreateRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
    }
}
