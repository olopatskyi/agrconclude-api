namespace agrconclude.core.Entities
{
    public class Contract : BaseContract
    {
        ICollection<UserContract> Users { get; set; }
        public bool IsSigned => !Users.Any(x=>!x.IsSigned);
    }
}