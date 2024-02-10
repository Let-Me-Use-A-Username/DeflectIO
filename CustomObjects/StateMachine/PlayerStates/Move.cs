using Godot;
using System;
using System.Collections.Generic;

public partial class Move : PlayerState
{
	public override void Process(double delta)
	{
		Vector3 velocity = player.LinearVelocity;
		
		if (velocity.X == 0 | velocity.Z == 0)
		{
			stateMachine.TransitionToState(this, stateMachine.states["Idle"]);
		}
	}

	private void Hello()
	{
		GD.Print("hello");
	}

	public override void PhysicsProcess(double delta)
	{
	}

	public override void UnhandledInput(InputEvent @event)
	{
	}

	public override void EnterState(Dictionary<Variant, Variant> parameters = null)
	{
		GD.Print("Entered State:", this.Name);
	}

	public override void ExitState(Dictionary<Variant, Variant> parameters = null)
	{
	}
}
