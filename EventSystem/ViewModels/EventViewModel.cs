namespace EventSystem.ViewModels
{
    public class EventViewModel
    {
        public int EventId { get; set; }

        public string EventName { get; set; }

        public string EventDescription { get; set; }

        public DateTime EventDate { get; set; }
        public int TotalSeats { get; set; }
        public int SeatsAvailable { get; set; }
    }
}
