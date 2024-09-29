using MovieBooking.Data.Models;
using MovieBooking.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBooking.Data.Repository
{
    public class ShowRepository : Repository<Show>, IShowRepository
    {
        public ShowRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
