namespace Events
{
    public class CreatePostEvent : Event
    {
        public string Id { get; set; }
        public string Title { get; set; }   
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}