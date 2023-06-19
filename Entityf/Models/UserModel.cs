using System.ComponentModel.DataAnnotations;

namespace Entityf.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]


        [StringLength(60, MinimumLength = 3,ErrorMessage = "more than 3 char required")]
        public string UserName { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]

        public bool MyCheckbox { get; set; }

        public string Gender { get; set; }
        [Required(ErrorMessage = "Please Select Gender")]
        public string Role { get; set; }

        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Please Select Date")]

        [Range(1, 25,ErrorMessage ="set range between 1-25")]
        public int Age { get; set; }

      
    }
}
