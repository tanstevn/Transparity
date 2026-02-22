using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transparity.Data.Entities;

namespace Transparity.Data.Configurations {
    internal class UserConfiguration : BaseConfiguration<User> {
        public override void Configure(EntityTypeBuilder<User> builder) {
            base.Configure(builder);

            builder.HasOne(user => user.Info)
                .WithOne(info => info.User);

            builder.HasOne(user => user.Role)
                .WithMany(role => role.Users)
                .HasForeignKey(user => user.RoleId);

            builder.HasMany(user => user.Requests)
                .WithOne(requests => requests.User)
                .HasForeignKey(requests => requests.UserId);

            builder.HasMany(user => user.Attachments)
                .WithOne(attachments => attachments.User)
                .HasForeignKey(attachments => attachments.UserId);

            builder.Navigation(user => user.Info)
                .AutoInclude();

            builder.Navigation(user => user.Role)
                .AutoInclude();
        }
    }
}
