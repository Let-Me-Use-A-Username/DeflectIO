using Godot;
using System;
using System.Collections.Generic;

public partial class DummyState : Node, State
{
    public Node3D player;
	public Dictionary<string, Variant> playerProperties;
	Vector3 movementDirection;

	public StateMachineTemplate stateMachine;
	public Dictionary<Variant, Variant> entryMessage;
	public Dictionary<Variant, Variant> exitMessage;
	
	public override async void _Ready()
	{
        if (stateMachine == null)
		{
			stateMachine = GetParent() as StateMachineTemplate;
		}

		await ToSignal(stateMachine, "ready");
        player = stateMachine.targetEntity as Node3D;

		playerProperties = new Dictionary<string, Variant>
        {
            { "direction", movementDirection }
        };

		entryMessage = new();
		exitMessage = new();
	}

	public virtual void Process(double delta)
	{
		movementDirection = Vector3.Zero;

		movementDirection.X = Input.GetAxis("left", "right");
		movementDirection.Z = Input.GetAxis("forward", "backward");

		playerProperties["direction"] = movementDirection;
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
