using System.ComponentModel.DataAnnotations;

namespace Common.Viewmodels
{
    public class Uservm : AuditableEntity<int>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string RepeatPassword { get; set; }
        public string email { get; set; }
    }
}