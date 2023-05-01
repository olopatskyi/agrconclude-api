namespace agrconclude.Domain.Entities
{
    public enum ContractStatus
    {
        Sent,
        InProgress,
        Signed,
        Canceled
    }
    
    public class Contract : BaseEntity
    {
        public string CreatorId { get; set; }

        public string ClientId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ExpiresAt { get; set; }

        public bool IsSigned { get; set; }

        public ContractStatus Status { get; set; }

        public AppUser? Creator { get; set; }
        public AppUser? Client { get; set; }
    }
}