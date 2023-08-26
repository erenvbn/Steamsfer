using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steamsfer.Models
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1,50)]
        public string Role { get; set; }

        [Range(1, 100)]
        public string Description { get; set; }

    }
}
