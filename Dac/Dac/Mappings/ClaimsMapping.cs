using Common.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dac.Mappings
{
    class ClaimsMapping
    {
        internal static void CreateMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<UserClaim>().Property(c => c.Id).HasColumnName("Claims_Id")
                                                            .HasColumnType(SqlDbType.Int.ToString());
        }
    }
}
