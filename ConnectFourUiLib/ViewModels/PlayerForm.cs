using System.ComponentModel.DataAnnotations;

namespace ConnectFourUiLib.ViewModels
{
    public class PlayerForm
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name is too short")]
        public string Name { get; set; }

        [Required]
        [RegularExpression("^#[A-Fa-f0-9]{6}$", ErrorMessage = "Invalid Color")]
        public string Color { get; set; }
    }
}
