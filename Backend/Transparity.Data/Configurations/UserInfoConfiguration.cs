using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transparity.Data.Entities;

namespace Transparity.Data.Configurations {
    internal class UserInfoConfiguration : BaseConfiguration<UserInfo> {
        public override void Configure(EntityTypeBuilder<UserInfo> builder) {
            base.Configure(builder);

            builder.HasIndex(info => info.Email);
            builder.HasIndex(info => info.Mobile);
            builder.HasOne(info => info.User)
                .WithOne(user => user.Info);
        }
    }
}
