namespace Transparity.Data.Abstractions {
    public interface ISoftDelete {
        public DateTime? DeletedAt { get; set;  }
    }
}
