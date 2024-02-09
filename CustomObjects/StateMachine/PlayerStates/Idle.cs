using Godot;
using System;
using System.Collections.Generic;

public partial class Idle : PlayerState
{
	Vector3 movementInput;

	public override void _Ready()
	{
		base._Ready();
	}

	public new void Process(double delta)
	{
		GD.Print("Idle Player velocity ");
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

	public new void PhysicsProcess(double delta)
	{
	}

	public new void UnhandledInput(InputEvent @event)
	{
	}

	public new void EnterState(Dictionary<Variant, Variant> parameters = null)
	{
		GD.Print("Entered State:", this.Name);
	}

	public new void ExitState(Dictionary<Variant, Variant> parameters = null)
	{
	}
}
