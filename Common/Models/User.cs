using Common.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class User : AuditableEntity<int>
    {
        public User()
        {
            this.Roles = new List<Role>();
        }
        
        [Required]
        public string Name { get; set; }
        public string password { get; set; }
        public string FacebookId { get; set; }
        public string email { get; set; }
        public Guid ActivationCode { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public IList<Role> Roles { get; set; }
    }
}