namespace IranFilmPort.Domain.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime InsertDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public DateTime? DeleteDateTime { get; set; }
    }
}
