using Godot;
using System;
using System.Collections.Generic;

public partial class DummyIdle : DummyState
{
    public override void Process(double delta)
	{
		base.Process(delta);
		
		Vector3 direction = (Vector3)dummyProperties["direction"];

		if (direction != Vector3.Zero)
		{
			TransitionEvent.Fire(this, 
				stateMachine.states["Move"], 
				new(){["animation"] = "knight_walk_in_place-loop"},
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

		anim.Play("Looped/knight_idle-loop");
		
	}

	public override void ExitState(Dictionary<Variant, Variant> parameters)
	{
	}
}
