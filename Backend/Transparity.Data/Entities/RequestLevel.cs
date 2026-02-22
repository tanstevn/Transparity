using Transparity.Data.Abstractions;

namespace Transparity.Data.Entities {
    public class RequestLevel : IId {
        public long Id { get; }
        public short Level { get; private set; }
        public string Name { get; private set; } = default!;
        public string Description { get; private set; } = default!;

        public virtual IEnumerable<Request> Requests { get; private set; } = default!;
    }
}
