using Godot;
using System;
using System.Collections.Generic;

public partial class DummyState : Node, State
{
	public AnimationPlayer anim;

    public RigidBody3D dummy;
	public Dictionary<string, Variant> dummyProperties;
	Vector3 movementDirection;

	public StateMachineTemplate stateMachine;
	
	public override async void _Ready()
	{
        if (stateMachine == null)
		{
			stateMachine = GetParent() as StateMachineTemplate;
		}

		await ToSignal(stateMachine, "ready");

		dummy = (RigidBody3D) stateMachine.targetEntity;
		dummyProperties = new Dictionary<string, Variant>
        {
			{ "velocity", dummy.LinearVelocity},
            { "direction", movementDirection }
        };

		anim = dummy.GetNode<AnimationPlayer>("AssetRoot/AnimationPlayer");
	}

	public virtual void Process(double delta)
	{
		movementDirection = Vector3.Zero;

		movementDirection.X = Input.GetAxis("left", "right");
		movementDirection.Z = Input.GetAxis("forward", "backward");

		dummyProperties["direction"] = movementDirection;
	}

	public virtual void PhysicsProcess(double delta)
	{
	}

	public virtual void UnhandledInput(InputEvent @event)
	{
	}

	public virtual void EnterState(Dictionary<Variant, Variant> parameters)
	{
	}

	public virtual void ExitState(Dictionary<Variant, Variant> parameters)
	{
	}
}
