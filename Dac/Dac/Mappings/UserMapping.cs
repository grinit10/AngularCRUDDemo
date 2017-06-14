using Common.Models;
using System.Data;
using System.Data.Entity;

namespace Dac.Mappings
{
    class UserMapping
    {
        internal static void CreateMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().Property(c => c.Id).HasColumnName("User_Id")
                                                            .HasColumnType(SqlDbType.Int.ToString());
        }
    }
}