using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduScoreAppBlazor.Shared.Models
{
    public class Subject
    {
        [Key]
        public int Id_Subject { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; } = string.Empty;

    }
}
