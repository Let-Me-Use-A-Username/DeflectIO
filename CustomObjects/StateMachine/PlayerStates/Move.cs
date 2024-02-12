using Godot;
using System;
using System.Collections.Generic;

public partial class Move : PlayerState
{
	public override void Process(double delta)
	{
		base.Process(delta);

		Vector3 velocity = (Vector3)playerProperties["velocity"];
		
		if (velocity.X == 0 & velocity.Z == 0)
		{
			stateMachine.TransitionToState(this, stateMachine.states["Idle"]);
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
