using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transparity.Data.Entities;

namespace Transparity.Data.Configurations {
    internal class RequestLevelConfiguration : BaseConfiguration<RequestLevel> {
        public override void Configure(EntityTypeBuilder<RequestLevel> builder) {
            base.Configure(builder);

            builder.HasMany(level => level.Requests)
                .WithOne(request => request.Level)
                .HasForeignKey(request => request.LevelId);
        }
    }
}
