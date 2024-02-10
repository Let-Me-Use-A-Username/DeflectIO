using Godot;
using System;
using System.Collections.Generic;

public partial class StateMachine : Node
{
	public Dictionary<string, State> states;
	public State activeState;
	public Node targetEntity;

	public override void _Ready()
	{
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


	public void TransitionToState(State origin, State next_state, Dictionary<Variant, Variant> exit_message = null, Dictionary<Variant, Variant> enter_message = null)
	{
		if (!states.ContainsValue(next_state))
		{
			return;
		}

		activeState.ExitState(exit_message);
		activeState = next_state;
		activeState.EnterState(enter_message);
	}
}


