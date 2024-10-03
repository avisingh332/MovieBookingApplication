using Microsoft.EntityFrameworkCore;
using MovieBooking.Data.Models;
using MovieBooking.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBooking.Data.Repository
{
    public class BookingRepository : Repository<UserBooking>, IBookingRepository
    {
       
        public BookingRepository(ApplicationDbContext db) : base(db)
        {

        }
       
    }
}
