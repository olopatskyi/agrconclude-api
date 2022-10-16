namespace agrconclude.core.Entities
{
    public class Contract : BaseContract
    {
        public Guid Id { get; set; }
        public ICollection<UserContract>? Users { get; set; }
    }
}