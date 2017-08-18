using System.ComponentModel.DataAnnotations;
namespace csharpbelt.Models
{
    public class RegisterViewModel : BaseEntity
    {
        [Key]
        public int UserId {get;set;}
        
         [Required]
         [MinLength(3)]
         [RegularExpression(@"^[a-zA-Z]+$")]
        public string FirstName { get; set; }

        [Required]
         [MinLength(3)]
         [RegularExpression(@"^[a-zA-Z]+$")]
        public string LastName { get; set; }
        [Required]
        [Range(0,99)]
         
        public int Age { get; set; }

                [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }
 
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }

       
        [Compare("Password", ErrorMessage = "Password and confirmation must match.")]
        public string ConfirmPassword { get; set; }
        
    }
}