using Transparity.Data.Abstractions;

namespace Transparity.Data.Entities {
    public class Request : IId, ISoftDelete {
        public long Id { get; }
        public string TrackingNumber { get; private set; } = default!;
        public long UserId { get; private set; }
        public long CategoryId { get; private set; }
        public long StatusId { get; private set; }
        public long LevelId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? ModifiedAt { get; private set; }
        public DateTime? DeletedAt { get; set; }

        public virtual User User { get; private set; } = default!;
        public virtual RequestCategory Category { get; private set; } = default!;
        public virtual RequestStatus Status { get; private set; } = default!;
        public virtual RequestLevel Level { get; private set; } = default!;
        public virtual IEnumerable<RequestComment> Comments { get; private set; } = default!;
        public virtual IEnumerable<RequestAttachment> Attachments { get; private set; } = default!;
        public virtual IEnumerable<RequestHistory> History { get; private set; } = default!;
    }
}
