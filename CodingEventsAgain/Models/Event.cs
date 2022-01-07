namespace CodingEventsAgain.Models
{
    public class Event
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Uid { get; }
        static private int nextId = 0;
        internal static bool initialized = false;
        //private static bool threeFirst = false;
        //static readonly int initialEvents = 3;

        public Event()
        {
            Uid = nextId;
            nextId++;
        }

        /*static public void MakeInitialized()
        {
            initialized = true;
        }
        static public void MakeThreeFirstDone()
        {
            threeFirst = true;
        }*/

        public Event(string name): this()
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
