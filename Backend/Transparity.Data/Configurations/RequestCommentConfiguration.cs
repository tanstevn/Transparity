using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transparity.Data.Entities;

namespace Transparity.Data.Configurations {
    internal class RequestCommentConfiguration : BaseConfiguration<RequestComment> {
        public override void Configure(EntityTypeBuilder<RequestComment> builder) {
            base.Configure(builder);

            builder.HasOne(comment => comment.Request)
                .WithMany(request => request.Comments)
                .HasForeignKey(comment => comment.RequestId);

            builder.HasOne(comment => comment.User)
                .WithMany(user => user.Comments)
                .HasForeignKey(comment => comment.UserId);
        }
    }
}
