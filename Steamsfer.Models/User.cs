using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steamsfer.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(5,20)]
        public string UserName { get; set; }

        [Required]
        [Range(1,250)]
        public string Email { get; set; }

        [Required]
        [Range(8, 40)]
        public string Password { get; set; }
        public string AvatarURL { get; set; }


        public int UserRoleId { get; set; } //Foreign Key Property in this class

        [ForeignKey("UserRoleId")]
        public UserRole UserRole { get; set; } //Navigation Property to UserRole table
    }
}
