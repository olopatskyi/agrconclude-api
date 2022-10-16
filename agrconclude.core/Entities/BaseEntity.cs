namespace agrconclude.core.Entities
{
    public abstract class BaseContract
    {        
        Guid CreatedById { get; set; }

        DateTime CreatedAt { get; set; }

        bool IsSigned { get; }

        AppUser? CreatedBy { get; set; }
    }
}