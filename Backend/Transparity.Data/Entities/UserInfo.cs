using Transparity.Data.Abstractions;

namespace Transparity.Data.Entities {
    public class UserInfo : IId {
        public long Id { get; }
        public string FirstName { get; private set; } = default!;
        public string LastName { get; private set; } = default!;
        public string? Email { get; private set; }
        public string? Mobile { get; private set; }
        public string Address1 { get; private set; } = default!;
        public string? Address2 { get; private set; }

        public virtual User User { get; private set; } = default!;
    }
}
