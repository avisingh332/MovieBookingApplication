﻿using MovieBooking.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBooking.Data.Repository.IRepository
{
    public interface IBookingRepository: IRepository<UserBooking>
    {
    }
}
