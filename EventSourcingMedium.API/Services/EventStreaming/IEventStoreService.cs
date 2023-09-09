namespace EventSourcingMedium.API.Services.EventStreaming
{
    public interface IEventStoreService
    {
        Task AppendEventAsync(object eventdata);
        Task<IEnumerable<EventResponse>> GetAllEvents(int start, int count);
    }
}
