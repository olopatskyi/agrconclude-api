namespace agrconclude.core.Entities
{
    public class UserContract 
    {
       public Guid Id { get; set; }

       public Guid AppUserId { get; set; }

       public Guid ContractId { get; set; }

       public bool IsSigned { get; set; }

       public AppUser? AppUser { get; set; }
       public Contract? Contract { get; set; }
    }
}