namespace EventSourcingMedium.API.Services.EventStreaming
{
    public class EventStoreDB
    {
        public const string ConnectionString = "ConnectTo=tcp://admin:changeit@localhost:1113; DefaultUserCredentials=admin:changeit;";
        public const string StreamName = "PostInformation";
        public const string TaskName = "PostInformationStrema";
    }
}
