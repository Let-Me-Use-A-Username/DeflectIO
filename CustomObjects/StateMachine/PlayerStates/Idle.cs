using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public partial class Idle : PlayerState
{

    public override void Process(double delta)
	{
		if (movementDirection != Vector3.Zero)
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
		GD.Print("Entered State:", this.Name);
	}

	public override void ExitState(Dictionary<Variant, Variant> parameters = null)
	{
	}
}
