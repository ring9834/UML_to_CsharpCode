namespace UML_to_CsharpCode
{
    public class House
    {
        // Composition: House contains Rooms, and Rooms cannot exist without the House
        // The part is typically created and destroyed along with the whole
        // The rooms list is private, and a read-only view is exposed to prevent external modification
        private List<Room> rooms = new List<Room>();

        public House()
        {
            rooms.Add(new Room("Living Room"));
            rooms.Add(new Room("Kitchen"));
        }

        public IReadOnlyList<Room> Rooms => rooms.AsReadOnly();
    }

    public class Room
    {
        public string Name { get; set; }

        public Room(string name)
        {
            Name = name;

        }
    }
}