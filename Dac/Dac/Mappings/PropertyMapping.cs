using Common.Models;
using System.Data;
using System.Data.Entity;

namespace Dac.Mappings
{
    class PropertyMapping
    {
        internal static void CreateMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>().ToTable("Property");
            modelBuilder.Entity<Property>().Property(c => c.Id).HasColumnName("Porperty_Id")
                                                            .HasColumnType(SqlDbType.Int.ToString());
        }
    }
}
