namespace CodingEventsAgain.Models
{
    public class Event
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Event(string name)
        {
            Name = name;
        }

        public Event(string name, string description): this(name)
        {
            Description = description;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
