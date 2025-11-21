using System.ComponentModel.DataAnnotations;

namespace StudentClaimsSystem.Models
{
    public class Module
    {
        public int Id { get; set; }
        [Required] public string Code { get; set; } = "";
        [Required] public string Name { get; set; } = "";
        public int Credits { get; set; }
        public int ClassHoursPerWeek { get; set; }
        public int WeeksInSemester { get; set; } = 15;

        public double SelfStudyHoursPerWeek =>
            Math.Max(0, (Credits * 10.0 / WeeksInSemester) - ClassHoursPerWeek);
    }
}