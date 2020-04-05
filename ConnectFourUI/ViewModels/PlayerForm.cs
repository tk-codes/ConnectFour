using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectFourUI.ViewModels
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
