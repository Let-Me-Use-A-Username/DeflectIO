using Godot;
using System;
using System.Collections.Generic;

public partial class Idle : PlayerState
{
	Vector3 movementInput;

	public override void Process(double delta)
	{
		Vector3 velocity = player.LinearVelocity;
		GD.Print("Idle Player velocity " + velocity);

		movementInput = Vector3.Zero;

		movementInput.X = Input.GetAxis("left", "right");
		movementInput.Z = Input.GetAxis("forward", "backward");

		if (movementInput != Vector3.Zero)
		{
			stateMachine.TransitionToState(this, (State)stateMachine.states["Move"], null, null);
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
