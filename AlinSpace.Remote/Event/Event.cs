using System.Text.Json;

namespace AlinSpace.Remote
{
    public class Event
    {
        public string Type { get; set; }

        public string Data { get; set; }

        public static Event Deserialize(string @event) => JsonSerializer.Deserialize<Event>(@event);

        public string Serialize() => JsonSerializer.Serialize(this);

        public bool IsType(Type type) => type?.FullName == Type;

        public T DeserializeData<T>() => JsonSerializer.Deserialize<T>(Data);
    }
}
