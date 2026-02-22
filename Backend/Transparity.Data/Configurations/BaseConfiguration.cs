using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transparity.Data.Extensions;

namespace Transparity.Data.Configurations {
    internal abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder) {
            builder
                .ConfigureId()
                .ConfigureSoftDelete();
        }
    }
}
