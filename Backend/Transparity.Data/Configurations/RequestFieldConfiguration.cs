using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transparity.Data.Entities;

namespace Transparity.Data.Configurations {
    internal class RequestFieldConfiguration : BaseConfiguration<RequestField> {
        public override void Configure(EntityTypeBuilder<RequestField> builder) {
            base.Configure(builder);
        }
    }
}
