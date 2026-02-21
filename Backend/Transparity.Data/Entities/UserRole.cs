using Transparity.Data.Abstractions;

namespace Transparity.Data.Entities {
    public class UserRole : IId {
        public long Id { get; }
        public string Name { get; private set; } = default!;
        public string Description { get; private set; } = default!;

        public virtual User User { get; private set; } = default!;
    }
}
