namespace StudentClaimsSystem.Models
{
    public class Claim
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public Module Module { get; set; } = null!;

        public DateTime DateSubmitted { get; set; } = DateTime.Now;
        public double HoursClaimed { get; set; }
        public string Description { get; set; } = "";
        public string? DocumentPath { get; set; }
        public string Status { get; set; } = "Pending";
        public double? VerifiedHours { get; set; }
    }
}