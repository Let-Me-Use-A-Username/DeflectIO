using Godot;
using System;
using System.Collections.Generic;

public partial class State : Node
{
	public override void _Ready()
	{
        base._Ready();
	}

	public void Process(double delta)
	{
	}

	public void PhysicsProcess(double delta)
	{
	}

	public void UnhandledInput(InputEvent @event)
	{
	}

	public void EnterState(Dictionary<Variant, Variant> parameters = null)
	{
	}

	public void ExitState(Dictionary<Variant, Variant> parameters = null)
	{
	}
}
