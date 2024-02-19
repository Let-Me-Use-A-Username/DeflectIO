using System;
using System.Collections.Generic;
using System.Linq;

namespace Impentum.Events;

public interface IEvent {}

public interface IEventListener
{
    internal int GetObjectId();

    internal void Trigger(IEvent @event);

    internal Type GetListenerType();

}

public readonly struct EventListener<T> : IEventListener
{
    private readonly int _objectId;
    private readonly Type _type;
    private readonly EventManager.EventDelegate<IEvent> _delegate;

    internal EventListener(int objectId, EventManager.EventDelegate<IEvent> @delegate)
    {
        _objectId = objectId;
        _type = typeof(T);
        _delegate = @delegate;
    }

    Type IEventListener.GetListenerType()
    {
        return _type;
    }

    int IEventListener.GetObjectId()
    {
        return _objectId;
    }

    void IEventListener.Trigger(IEvent @event)
    {
	    _delegate?.Invoke(@event);
    }

}

public static class EventManager
{
	public delegate void EventDelegate<T>(T @event) where T : IEvent;

	private static readonly Dictionary<Type, Dictionary<int, IEventListener>> Listeners = new();

	public static EventListener<T> Listen<T>(in object register, EventDelegate<T> @delegate) where T : IEvent 
	{
		Type type = typeof(T);
		if(!Listeners.ContainsKey(type))
		{
			Listeners.Add(type, new Dictionary<int, IEventListener>());
		}

		int objectId = register.GetHashCode();
		EventListener<T> listener = new EventListener<T>(objectId, e => { @delegate((T)e); });
		Listeners[type].Add(objectId, listener);
		return listener;
	}

	public static void ResetListener<T>() where T : IEvent 
	{
		Listeners.Remove(typeof(T));
	}

	public static void SendEvent<T>(T @event) where T : IEvent
	{
		Type type = typeof(T);
		if(!Listeners.ContainsKey(type)) return;
		var typeListeners = Listeners[type];
		var keys = typeListeners.Keys.ToArray();
		for(int i = 0; i < keys.Length; ++i)
		{
			int key = keys[i];
			if (!typeListeners.ContainsKey(key)) continue;
			typeListeners[key].Trigger(@event);
		}
	}

	public static void RemoveListener<T>(ref T listener) where T : IEventListener
	{
		Type type = listener.GetListenerType();
		if(!Listeners.ContainsKey(type)) return;
		Listeners[type].Remove(listener.GetObjectId());
		listener = default;
	} 

}
