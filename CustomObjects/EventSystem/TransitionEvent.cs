using Godot;
using Impentum.Events;
using System.Collections.Generic;

public sealed class TransitionEvent : IEvent
{
    public State origin;
    public State destination;
    public Dictionary<Variant, Variant> entryMessage;
    public Dictionary<Variant, Variant> exitMessage;

    private static TransitionEvent _instance = new();

    public static void Fire(State origin, State destination, Dictionary<Variant, Variant> entryMessage, Dictionary<Variant, Variant> exitMessage)
    {
        _instance.origin = origin;
        _instance.destination = destination;
        _instance.entryMessage = entryMessage;
        _instance.exitMessage = exitMessage;
        EventManager.SendEvent(_instance);
    }
}
