using Godot;
using System;
using System.Collections.Generic;

public partial class DummyWalk : DummyState
{
	public override void Process(double delta)
	{
		base.Process(delta);

		Vector3 direction = (Vector3)dummyProperties["direction"];

		dummy.ApplyCentralForce(direction * 1200.0F * (float)delta);
		
		if (direction == Vector3.Zero)
		{
			TransitionEvent.Fire(this, 
				stateMachine.states["Idle"], 
				new(){["animation"] = "knight_idle-loop"},
				new(){}
				);
		}
	}

	public override void PhysicsProcess(double delta)
	{
	}

	public override void UnhandledInput(InputEvent @event)
	{
	}

	public override void EnterState(Dictionary<Variant, Variant> parameters)
	{
		GD.Print("Entered State:", Name);

		anim.Play("Looped/knight_walk_in_place-loop");
		
	}

	public override void ExitState(Dictionary<Variant, Variant> parameters)
	{
	}
}
