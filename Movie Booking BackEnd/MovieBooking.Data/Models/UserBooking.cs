﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBooking.Data.Models
{
    public class UserBooking
    {
        public Guid Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        [ForeignKey("Show")]
        public Guid ShowId { get; set; }
        [Required]
        public int SeatsBooked { get; set; }
        public DateTime BookingDate { get; set; }
        // Navigation Properties
        public virtual Show Show{ get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
