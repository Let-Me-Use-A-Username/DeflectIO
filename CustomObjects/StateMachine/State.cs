using Godot;
using System;
using System.Collections.Generic;

public interface State
{
	public void Start()
	{
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
