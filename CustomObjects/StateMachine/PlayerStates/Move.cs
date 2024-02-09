using Godot;
using System;
using System.Collections.Generic;

public partial class Move : PlayerState
{
	public override void Process(double delta)
	{
		Vector3 velocity = player.LinearVelocity;
		GD.Print("Move Player velocity " + velocity);
	}

	public override void PhysicsProcess(double delta)
	{
	}

	public override void UnhandledInput(InputEvent @event)
	{
	}

	public override void EnterState(Dictionary<Variant, Variant> parameters = null)
	{
		GD.Print("State:", this.Name);
	}

	public override void ExitState(Dictionary<Variant, Variant> parameters = null)
	{
	}
}
