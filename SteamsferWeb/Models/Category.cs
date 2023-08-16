using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace SteamsferWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field cannot be empty")]
        [MaxLength(30, ErrorMessage ="Should be lower than 30 characters")]
        public string Name { get; set; }

        [Range(1,100, ErrorMessage ="Please give invalid credentials.")]
        public int DisplayOrder { get; set; }

    }
}
