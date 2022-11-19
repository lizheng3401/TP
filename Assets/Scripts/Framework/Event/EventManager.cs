using System;

namespace TP.Event
{
    public class EventManager : BaseModule
    {
        private readonly EventPool<GameEventArgs> _eventPool;

        public EventManager()
        {
            _eventPool = new EventPool<GameEventArgs>();
        }
        
        internal override void Tick(float elapseSeconds, float realElapseSeconds)
        {
            _eventPool.Tick(elapseSeconds, realElapseSeconds);
        }

        internal override void ShutDown()
        {
            _eventPool.ShutDown();
        }

        public void Subscribe(int id, EventHandler<GameEventArgs> eventHandler)
        {
            _eventPool.Subscribe(id, eventHandler);
        }
        
        public void Unsubscribe(int id, EventHandler<GameEventArgs> eventHandler)
        {
            _eventPool.Unsubscribe(id, eventHandler);
        }
        
        public void Subscribe(TPEventType eventType, EventHandler<GameEventArgs> eventHandler)
        {
            _eventPool.Subscribe((int)eventType, eventHandler);
        }
        
        public void Unsubscribe(TPEventType eventType, EventHandler<GameEventArgs> eventHandler)
        {
            _eventPool.Unsubscribe((int)eventType, eventHandler);
        }

        public void Fire(object sender, GameEventArgs eventArgs)
        {
            _eventPool.Fire(sender, eventArgs);
        }
    }
}