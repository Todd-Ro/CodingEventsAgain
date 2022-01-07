namespace CodingEventsAgain.Models
{
    public class Event
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Uid { get; }
        static private int nextId = 1;

        public Event(string name)
        {
            Name = name;
            Uid = nextId;
            nextId++;
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
