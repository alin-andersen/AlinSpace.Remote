using System.Reactive.Linq;

namespace AlinSpace.Remote
{
    public static class ObservableExtensions
    {
        public static IObservable<T> Where<T>(this IObservable<Event> observable)
        {
            return observable
                .Where(x => x.IsType(typeof(T)))
                .Select(x => x.DeserializeData<T>());
        }
    }
}
