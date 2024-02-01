namespace Game.Core.ObserverPattern
{
    public interface IObserver
    {
        void OnNotify(EventKey key);
    }
}