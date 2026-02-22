using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transparity.Data.Entities;

namespace Transparity.Data.Configurations {
    internal class RequestAttachmentConfiguration : BaseConfiguration<RequestAttachment> {
        public override void Configure(EntityTypeBuilder<RequestAttachment> builder) {
            base.Configure(builder);

            builder.HasIndex(attachment => attachment.FileName);

            builder.HasOne(attachment => attachment.Request)
                .WithMany(request => request.Attachments)
                .HasForeignKey(attachment => attachment.RequestId);

            builder.HasOne(attachment => attachment.User)
                .WithMany(user => user.Attachments)
                .HasForeignKey(attachment => attachment.UserId);
        }
    }
}
