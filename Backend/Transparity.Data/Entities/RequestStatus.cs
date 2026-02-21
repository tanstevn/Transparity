using Transparity.Data.Abstractions;

namespace Transparity.Data.Entities {
    public class RequestStatus : IId, ISoftDelete {
        public long Id { get; }
        public string Name { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public DateTime CreatedAt { get; private set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Request Request { get; private set; } = default!;
        public virtual IEnumerable<RequestHistory> History { get; private set; } = default!;
    }
}
