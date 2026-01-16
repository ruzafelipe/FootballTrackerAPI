namespace FootballTracker.API.DTOs.Clubs
{
    public sealed class ClubResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Country { get; set; } = null!;
        public DateTime? FoundedAt { get; set; }
        public string? LogoUrl { get; set; }
        public bool IsActive { get; set; }                
    }
}
