using System.Data.Entity;
using Common.Models;
using System.Data;

namespace Dac.Mappings
{
    class UserRoleMapping
    {
        internal static void CreateMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().ToTable("User_Role");
            modelBuilder.Entity<UserRole>().Property(c => c.Id).HasColumnName("User_Role_Id")
                                                            .HasColumnType(SqlDbType.Int.ToString());
        }
    }
}
