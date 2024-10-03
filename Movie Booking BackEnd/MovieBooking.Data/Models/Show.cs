using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBooking.Data.Models
{
    public class Show
    {
        public Guid Id { get; set; }

        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }

        public int ScreenNo { get; set; }
        public int NoOfSeats { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [Required]
        public decimal Price { get; set; }

        //Navigation Property 
        public virtual Movie Movie { get; set; }

    }
}
