using Godot;
using System;
using System.Collections.Generic;

public class EventArguments : EventArgs
{
    public State origin { get; set;}
	public State dest { get; set;}
	public Dictionary<Variant, Variant> entryMessage;
	public Dictionary<Variant, Variant> exitMessage;
}
