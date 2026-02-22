using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transparity.Data.Entities;

namespace Transparity.Data.Configurations {
    internal class RequestConfiguration : BaseConfiguration<Request> {
        public override void Configure(EntityTypeBuilder<Request> builder) {
            base.Configure(builder);

            builder.HasIndex(request => request.TrackingNumber)
                .IsUnique();

            builder.HasOne(request => request.User)
                .WithMany(user => user.Requests)
                .HasForeignKey(request => request.UserId);

            builder.HasOne(request => request.Category)
                .WithMany(category => category.Requests)
                .HasForeignKey(request => request.CategoryId);

            builder.HasOne(request => request.Status)
                .WithMany(status => status.Requests)
                .HasForeignKey(request => request.StatusId);

            builder.HasOne(request => request.Level)
                .WithMany(level => level.Requests)
                .HasForeignKey(request => request.LevelId);

            builder.HasMany(request => request.Comments)
                .WithOne(comment => comment.Request)
                .HasForeignKey(comment => comment.RequestId);

            builder.HasMany(request => request.Attachments)
                .WithOne(attachment => attachment.Request)
                .HasForeignKey(attachment => attachment.RequestId);

            builder.HasMany(request => request.History)
                .WithOne(history => history.Request)
                .HasForeignKey(history => history.RequestId);

            builder.Navigation(request => request.User)
                .AutoInclude();

            builder.Navigation(request => request.Category)
                .AutoInclude();

            builder.Navigation(request => request.Status)
                .AutoInclude();

            builder.Navigation(request => request.Level)
                .AutoInclude();

            builder.Navigation(request => request.Comments)
                .AutoInclude();

            builder.Navigation(request => request.Attachments)
                .AutoInclude();

            builder.Navigation(request => request.History)
                .AutoInclude();
        }
    }
}
