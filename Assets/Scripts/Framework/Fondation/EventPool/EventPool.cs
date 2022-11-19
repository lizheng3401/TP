using System;
using System.Collections.Generic;
using TP.Event;
using UnityEngine.EventSystems;

public sealed class EventPool<T> where T: BaseEventArgs
{
    private readonly Dictionary<int, LinkedList<EventHandler<T>>> _eventHandlers;
    private Queue<Event> _events;

    class Event
    {
        public object Sender;
        public T EventArgs;
    }
        
    
    public EventPool()
    {
        _eventHandlers = new Dictionary<int, LinkedList<EventHandler<T>>>();
    }

    public void Tick(float elapseSeconds, float realElapseSeconds)
    {
        lock (_events)
        {
            while (_events.Count > 0)
            {
                Event currentEvent = _events.Dequeue();
                HandlerEvent(currentEvent.Sender, currentEvent.EventArgs);
            }
        }
    }

    public void ShutDown()
    {
        
    }

    private void HandlerEvent(object sender, T eventArgs)
    {
        LinkedList<EventHandler<T>> handlers = default(LinkedList<EventHandler<T>>);
        if (_eventHandlers.TryGetValue(eventArgs.Id, out handlers))
        {
            for (LinkedListNode<EventHandler<T>> currentHandler = handlers.First;
                 currentHandler != null;
                 currentHandler = currentHandler.Next)
            {
                currentHandler.Value(sender, eventArgs);
            }
        }
    }

    public void Subscribe(int id, EventHandler<T> handler)
    {
        LinkedList<EventHandler<T>> eventChain = default(LinkedList<EventHandler<T>>);
        if (!_eventHandlers.ContainsKey(id))
        {
            eventChain = new LinkedList<EventHandler<T>>();
            _eventHandlers.Add(id, eventChain);
        }

        _eventHandlers[id].AddLast(handler);
    }
    
    public void Unsubscribe(int id, EventHandler<T> handler)
    {
        LinkedList<EventHandler<T>> eventChain = default(LinkedList<EventHandler<T>>);
        if (!_eventHandlers.ContainsKey(id))
        {
            eventChain = _eventHandlers[id];
            if (eventChain.Contains(handler))
            {
                eventChain.Remove(handler);
            }

            if (eventChain.Count == 0)
            {
                _eventHandlers.Remove(id);
            }
        }
    }

    public void Fire(object sender, T eventArgs)
    {
        Event newEvent = new Event();
        newEvent.Sender = sender;
        newEvent.EventArgs = eventArgs;
        lock (_events)
        {
            _events.Enqueue(newEvent);
        }
    }
    
}