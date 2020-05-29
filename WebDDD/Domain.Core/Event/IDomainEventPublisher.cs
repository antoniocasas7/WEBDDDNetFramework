namespace Domain.Core.Event
{
    public interface IDomainEventPublisher
    {
        void Publish(IDomainEvent @event);
    }
}
