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
    public class ShowRepository : Repository<Show>, IShowRepository
    {
        private readonly ApplicationDbContext _db; 
        public ShowRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task UpdateAsync(Show show)
        {
            _db.Shows.Update(show);
            await _db.SaveChangesAsync();
        }
    }
}
