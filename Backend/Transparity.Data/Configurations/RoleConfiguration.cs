using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transparity.Data.Entities;

namespace Transparity.Data.Configurations {
    internal class RoleConfiguration : BaseConfiguration<Role> {
        public override void Configure(EntityTypeBuilder<Role> builder) {
            base.Configure(builder);

            builder.HasMany(role => role.Users)
                .WithOne(user => user.Role)
                .HasForeignKey(user => user.RoleId);
        }
    }
}
