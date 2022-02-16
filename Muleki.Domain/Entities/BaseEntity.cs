namespace Muleki.Domain.Entities
{
    public abstract class BaseEntity
    {
        protected long Id { get; set; }
        protected DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public DateTime Deleted_At { get; set; }
        
        internal List<string> _errors;
        public IReadOnlyCollection<string> Errors => _errors;

        protected BaseEntity()
        {
            _errors = new List<string>();
            Created_At = DateTime.Now;
        }

        public abstract bool Validate();
    }
}