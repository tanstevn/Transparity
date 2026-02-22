using Transparity.Data.Abstractions;

namespace Transparity.Data.Entities {
    public class RequestAttachment : IId, ISoftDelete {
        public long Id { get; }
        public long RequestId { get; private set; }
        public long UserId { get; private set; }
        public string FileName { get; private set; } = default!;
        public long FileSize { get; private set; }
        public string StoredFileName { get; private set; } = default!;
        public string StoragePath { get; private set; } = default!;
        public string ContentType { get; private set; } = default!;
        public DateTime CreatedAt { get; private set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Request Request { get; private set; } = default!;
        public virtual User User { get; set; } = default!;
    }
}
