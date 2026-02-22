using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transparity.Data.Entities;

namespace Transparity.Data.Configurations {
    internal class RequestStatusConfiguration : BaseConfiguration<RequestStatus> {
        public override void Configure(EntityTypeBuilder<RequestStatus> builder) {
            base.Configure(builder);

            builder.HasMany(status => status.Requests)
                .WithOne(request => request.Status)
                .HasForeignKey(request => request.StatusId);
        }
    }
}
