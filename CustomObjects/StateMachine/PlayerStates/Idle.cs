using Godot;
using System;
using System.Collections.Generic;

public partial class Idle : PlayerState
{

    public override void Process(double delta)
	{
		base.Process(delta);
		
		Vector3 direction = (Vector3)playerProperties["direction"];

		if (direction != Vector3.Zero)
		{
			stateMachine.TransitionToState(this, stateMachine.states["Move"]);
		}
	}

	public override void PhysicsProcess(double delta)
	{
	}

	public override void UnhandledInput(InputEvent @event)
	{
	}

	public override void EnterState(Dictionary<Variant, Variant> parameters = null)
	{
		GD.Print("Entered State:", Name);
	}

	public override void ExitState(Dictionary<Variant, Variant> parameters = null)
	{
	}
}
