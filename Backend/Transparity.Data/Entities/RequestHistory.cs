using Transparity.Data.Abstractions;

namespace Transparity.Data.Entities {
    public class RequestHistory : IId {
        public long Id { get; }
        public long RequestId { get; private set; }
        public long FieldId { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public string From { get; private set; } = default!;
        public string To { get; private set; } = default!;
        public DateTime CreatedAt { get; private set; }

        public virtual Request Request { get; private set; } = default!;
        public virtual IEnumerable<RequestField> Fields { get; private set; } = default!;
    }
}
