namespace agrconclude.Domain.Entities
{
    public class Contract
    {
        public Guid DocumentId { get; set; }

        public Guid CreatorId { get; set; }

        public Guid ClientId { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsSigned { get; }


        public AppUser? Creator { get; set; }
        public AppUser? Client { get; set; }
    }
}