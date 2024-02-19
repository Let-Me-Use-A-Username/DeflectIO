using Godot;
using Impentum.Events;
using System.Collections.Generic;

public partial class StateMachine : Node
{
	TransitionEvent transitionEvent = new();
	public Dictionary<string, State> states;
	public State activeState;
	public Node targetEntity;

	public override void _Ready()
	{
		EventManager.Listen<TransitionEvent>(transitionEvent, Transition);
		
		targetEntity = Owner;
		states = new Dictionary<string, State>();

		foreach (Node child in GetChildren())
		{
			if (child is State)
			{
				child.Set("stateMachine", this);
				states.Add(child.Name , (State)child);
			}
		}

		activeState = states["Idle"];
		activeState.EnterState();
	}

    public override void _Process(double delta)
	{
		if (activeState != null)
			activeState.Process(delta);
	}

    public override void _PhysicsProcess(double delta)
    {
		if (activeState != null)
			activeState.PhysicsProcess(delta);
    }


    public override void _UnhandledInput(InputEvent @event)
    {
		if (activeState != null)
        	activeState.UnhandledInput(@event);
    }

	
    private void Transition(TransitionEvent @event)
    {
		State originState = @event.origin;
		State nextState = @event.destination;

		Dictionary<Variant, Variant> entryMessage = @event.entryMessage;
		Dictionary<Variant, Variant> exitMessage = @event.exitMessage;

		if (!states.ContainsValue(nextState))
		{
			return;
		}
		
		activeState.ExitState(exitMessage);
		activeState = nextState;
		activeState.EnterState(entryMessage);
    }
}


