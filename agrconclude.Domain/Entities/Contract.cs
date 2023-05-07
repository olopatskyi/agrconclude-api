namespace agrconclude.Domain.Entities
{
    public enum ContractStatus
    {
       Pending,
       Concluded,
       Declined
    }
    
    public class Contract : BaseEntity
    {
        public string Label { get; set; }
        
        public string CreatorId { get; set; }

        public string ClientId { get; set; }

        public string DocumentId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ExpireAt { get; set; }

        public string Description { get; set; }
        public ContractStatus Status { get; set; }

        public AppUser? Creator { get; set; }
        public AppUser? Client { get; set; }
    }
}