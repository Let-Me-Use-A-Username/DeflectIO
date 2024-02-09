using Godot;
using System;
using System.Collections.Generic;

public partial class Move : PlayerState
{
	public override void _Ready()
	{
		base._Ready();
	}
	public new void Process(double delta)
	{
		Vector3 velocity = player.LinearVelocity;
		GD.Print("Move Player velocity " + velocity);
	}

	public new void PhysicsProcess(double delta)
	{
	}

	public new void UnhandledInput(InputEvent @event)
	{
	}

	public new void EnterState(Dictionary<Variant, Variant> parameters = null)
	{
		GD.Print("State:", this.Name);
	}

	public new void ExitState(Dictionary<Variant, Variant> parameters = null)
	{
	}
}
