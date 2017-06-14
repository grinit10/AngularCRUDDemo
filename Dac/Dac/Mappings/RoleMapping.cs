using Common.Models;
using System.Data;
using System.Data.Entity;

namespace Dac.Mappings
{
    class RoleMapping
    {
        internal static void CreateMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Role>().Property(c => c.Id).HasColumnName("Role_Id")
                                                                .HasColumnType(SqlDbType.Int.ToString());
        }
        
    }
}
