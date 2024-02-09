using Godot;
using System;
using System.Collections.Generic;

public partial class PlayerState : Node, State
{
    public RigidBody3D player;
	public StateMachine stateMachine;

	public override void _Ready()
	{
        if (stateMachine == null)
		{
			stateMachine = GetParent() as StateMachine;
		}

        if (player == null)
        {
            player = stateMachine.targetEntity as RigidBody3D;
        }
	}

	public virtual void Process(double delta)
	{
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
