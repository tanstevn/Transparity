using Transparity.Data.Abstractions;

namespace Transparity.Data.Entities {
    public class RequestComment : IId, ISoftDelete {
        public long Id { get; }
        public long RequestId { get; private set; }
        public long UserId { get; private set; }
        public string Comment { get; private set; } = default!;
        public DateTime CreatedAt { get; private set; }
        public DateTime? ModifiedAt { get; private set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Request Request { get; private set; } = default!;
        public virtual User User { get; private set; } = default!;
        public virtual IEnumerable<RequestAttachment> Attachments { get; private set; } = default!;
    }
}
