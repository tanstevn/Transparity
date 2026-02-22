using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transparity.Data.Entities;

namespace Transparity.Data.Configurations {
    internal class RequestHistoryConfiguration : BaseConfiguration<RequestHistory> {
        public override void Configure(EntityTypeBuilder<RequestHistory> builder) {
            base.Configure(builder);

            builder.HasOne(history => history.Request)
                .WithMany(request => request.History)
                .HasForeignKey(history => history.RequestId);

            builder.HasOne(history => history.Field)
                .WithMany(field => field.History)
                .HasForeignKey(history => history.FieldId);
        }
    }
}
