using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transparity.Data.Entities;

namespace Transparity.Data.Configurations {
    internal class RequestCategoryConfiguration : BaseConfiguration<RequestCategory> {
        public override void Configure(EntityTypeBuilder<RequestCategory> builder) {
            base.Configure(builder);

            builder.HasMany(category => category.Requests)
                .WithOne(request => request.Category)
                .HasForeignKey(request => request.CategoryId);
        }
    }
}
