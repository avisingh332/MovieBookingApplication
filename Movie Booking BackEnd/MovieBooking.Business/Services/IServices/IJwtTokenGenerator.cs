﻿using MovieBooking.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBooking.Business.Services.IServices
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken( ApplicationUser user, IEnumerable<string> Roles);
    }
}
