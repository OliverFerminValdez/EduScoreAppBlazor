using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduScoreAppBlazor.Shared.Models
{
    public class Student
    {
        [Key]
        public int Id_Student { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field is required")]
        public DateTime BirthDate { get; set; } = DateTime.Now;
        [Range(1,100)]
        public int Grade { get; set; }
        [ForeignKey("Id_Student")]
        public virtual List<ScoreDetail> ScoreDetail { get; set; } = new List<ScoreDetail>();

    }

    public class ScoreDetail
    {
        [Key]
        public int Id_Detail { get; set; }
        public int Id_Student { get; set; }
        public int Id_Subject { get; set; }
        public float Score { get; set; }

    }
}
