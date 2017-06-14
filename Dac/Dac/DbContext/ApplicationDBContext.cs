using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Common.Models;
using System.Threading;
using System.Data;
using Dac.Interfaces;
using Dac.Mappings;
using Common.Identity;

namespace Dac.DbContext
{
    public class ApplicationDBContext : System.Data.Entity.DbContext, IApplicationDBContext
    {
        public ApplicationDBContext()
            : base("name=PropertyConnstr")
        {
        }

        public IDbSet<Property> Properties { get; set; }
        public IDbSet<Company> Companies { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<UserRole> UserRoles { get; set; }
        //public IDbSet<UserClaim> UserClaims { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            CompanyMapping.CreateMapping(modelBuilder);
            PropertyMapping.CreateMapping(modelBuilder);
            UserMapping.CreateMapping(modelBuilder);
            UserRoleMapping.CreateMapping(modelBuilder);
            RoleMapping.CreateMapping(modelBuilder);
            //ClaimsMapping.CreateMapping(modelBuilder);
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
              .Where(x => x.Entity is IAuditableEntity
                  && (x.State == System.Data.Entity.EntityState.Added || x.State == System.Data.Entity.EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                IAuditableEntity entity = entry.Entity as IAuditableEntity;
                if (entity != null)
                {
                    string identityName = Thread.CurrentPrincipal.Identity.Name;
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == System.Data.Entity.EntityState.Added)
                    {
                        entity.CreatedBy = identityName;
                        entity.CreatedDate = now;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }

                    entity.UpdatedBy = identityName;
                    entity.UpdatedDate = now;
                }
            }

            return base.SaveChanges();
        }
    }
}