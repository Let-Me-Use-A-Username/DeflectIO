using Godot;
using System;
using System.Collections.Generic;

public partial class PlayerState : Node, State
{
    public RigidBody3D player;
	public Dictionary<string, Variant> playerProperties;
	public StateMachine stateMachine;
	Vector3 movementDirection;
	
	public override async void _Ready()
	{
        if (stateMachine == null)
		{
			stateMachine = GetParent() as StateMachine;
		}

		await ToSignal(stateMachine, "ready");
        player = stateMachine.targetEntity as RigidBody3D;

		playerProperties = new Dictionary<string, Variant>
        {
            { "velocity", player.LinearVelocity },
            { "direction", movementDirection }
        };
	}

	public virtual void Process(double delta)
	{
		movementDirection = Vector3.Zero;

		movementDirection.X = Input.GetAxis("left", "right");
		movementDirection.Z = Input.GetAxis("forward", "backward");

		playerProperties["direction"] = movementDirection;
		playerProperties["velocity"] = player.LinearVelocity;
	}

	public virtual void PhysicsProcess(double delta)
	{
	}

	public virtual void UnhandledInput(InputEvent @event)
	{
	}

	public virtual void EnterState(Dictionary<Variant, Variant> parameters = null)
	{
	}

	public virtual void ExitState(Dictionary<Variant, Variant> parameters = null)
	{
	}
}
