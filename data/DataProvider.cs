using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P_Cat_1_IDWM.Model;

namespace P_Cat_1_IDWM.data
{
    public class DataProvider : DbContext
    {
        
        public DataProvider(DbContextOptions options) : base(options) {}

        public DbSet<User> Users {get; set;} = null;

    }

}