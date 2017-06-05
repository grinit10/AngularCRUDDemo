using System;
using System.Collections.Generic;
using System.Linq;
using Common.Models;
using System.Data.Entity;

namespace AngularCRUDDemo.Dbcontext
{
    public class CRUDbcontext : DbContext
    {
        public DbSet<Property> properties { get; set; }
    }
}