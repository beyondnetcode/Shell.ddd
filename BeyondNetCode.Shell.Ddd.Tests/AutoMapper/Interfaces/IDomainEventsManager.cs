using BeyondNetCode.Shell.Ddd.Interfaces;

namespace BeyondNetCode.Shell.Ddd.Services.Impl
{
    public interface IDomainEventsManager
    {
        int Version { get; set; }

        void ApplyChange(IDomainEvent domainEvent, bool isNew);
        IReadOnlyCollection<IDomainEvent> GetUncommittedChanges();
        void LoadFromHistory(IReadOnlyCollection<IDomainEvent> history);
        void MarkChangesAsCommitted();
        void ReplayEvents(IEnumerable<IDomainEvent> domainEvents);
    }
}