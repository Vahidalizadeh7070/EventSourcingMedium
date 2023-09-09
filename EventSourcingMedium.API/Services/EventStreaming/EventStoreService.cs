using EventStore.ClientAPI;
using Newtonsoft.Json;
using System.Text;

namespace EventSourcingMedium.API.Services.EventStreaming
{
    public class EventStoreService : IEventStoreService
    {
        private readonly ILogger<EventStoreService> _logger;
        private readonly IEventStoreConnection _eventStoreConnection;

        public EventStoreService(ILogger<EventStoreService> logger,IEventStoreConnection eventStoreConnection)
        {
            _logger = logger;
            _eventStoreConnection = eventStoreConnection;
        }
        public async Task AppendEventAsync(object eventdata)
        {
            try
            {
                var eventPayload = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(eventdata));
                var eventDataInfo = new EventData
                (
                    Guid.NewGuid(),
                    eventdata.GetType().Name,
                    true,
                    eventPayload,
                    null
                    
                );
                await _eventStoreConnection.AppendToStreamAsync(EventStoreDB.StreamName, ExpectedVersion.Any, eventDataInfo);
                _logger.LogInformation("Event Appended to EventStoreDB");
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<EventResponse>> GetAllEvents(int start, int count)
        {
            var streamEvents = new List<EventResponse>();
            StreamEventsSlice currentSlice;
            var nextSliceStart = StreamPosition.Start;
            do
            {
                currentSlice = await _eventStoreConnection.ReadStreamEventsForwardAsync(EventStoreDB.StreamName,
                    nextSliceStart, 200, false);
                nextSliceStart = Convert.ToInt32(currentSlice.NextEventNumber);
                foreach (var item in currentSlice.Events)
                {
                    var eventData = item.Event;
                    var eventType = eventData.EventType;
                    var eventPayload = eventData.Data;
                    var deserializeObject = DeserializeEvent(eventData, eventType);
                    streamEvents.Add(deserializeObject);
                }
            } while (!currentSlice.IsEndOfStream);
            return streamEvents;
        }

        private EventResponse DeserializeEvent(RecordedEvent eventData, string eventType)
        {
            var item = Encoding.UTF8.GetString(eventData.Data);
            var eventPayload = JsonConvert.DeserializeObject<EventResponse>(item);
            eventPayload.EventType = eventType;
            return eventPayload;
        }
    }
}
