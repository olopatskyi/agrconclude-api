using agrconclude.core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace agrconclude.dal.Configurations
{
    public class UserContractConfiguration : IEntityTypeConfiguration<UserContract>
    {
        public void Configure(EntityTypeBuilder<UserContract> builder)
        {
            builder.ToTable("UsersContracts");

            builder.HasOne(x => x.Contract)
                .WithMany(x => x.Users)
                .HasForeignKey(x=>x.ContractId);

            builder.HasOne(x => x.AppUser)
                .WithMany(x => x.Contracts)
                .HasForeignKey(x=>x.AppUserId);

        }
    }
}
