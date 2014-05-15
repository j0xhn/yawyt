using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YawytMvc2.Models
{
    public class SignInModel
    {
        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}