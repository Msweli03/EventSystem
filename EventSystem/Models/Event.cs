namespace EventSystem.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int TotalSeats { get; set; }
        public int SeatsAvailable { get; set; }
        public ICollection<Registration> Registrations { get; set; }
        public string Description { get; set; }


    }

}
