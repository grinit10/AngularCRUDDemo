using Common.Models;
using System.Data;
using System.Data.Entity;

namespace Dac.Mappings
{
    class CompanyMapping
    {
        internal static void CreateMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasMany(p => p.Properties).WithRequired();
            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<Company>().Property(c => c.Id).HasColumnName("Company_Id")
                                                            .HasColumnType(SqlDbType.Int.ToString());
        }
    }
}
