using Godot;
using System;

public partial class Player : RigidBody3D
{
	ConfigHandler configHandler;
	Node3D twistPivot;
	Node3D pitchPivot;
	float mouseSensitivity = 0.001F;
	float twistInput = 0.0F;
	float pitchInput = 0.0F;

	float speed = 1200.0F;	
	float health = 100.0F;

	public override void _Ready()
	{
		configHandler = GetNode<ConfigHandler>("ConfigHandler");
		twistPivot = GetNode<Node3D>("Twist_pivot");
		pitchPivot = GetNode<Node3D>("Twist_pivot/Pitch_pivot");

		Input.MouseMode = Input.MouseModeEnum.Captured;
		configHandler.InitializeDefaultConfig(this, true);
	}

	public override void _Process(double delta)
	{
		Vector3 movement_input = Vector3.Zero;
		movement_input.X = Input.GetAxis("left", "right");
		movement_input.Z = Input.GetAxis("forward", "backward");

		float _delta = (float)delta;
		ApplyCentralForce(twistPivot.Basis * movement_input.Normalized() * speed * _delta);
	
		if (Input.IsActionPressed("ui_cancel")){
			Input.MouseMode = Input.MouseModeEnum.Visible;
		}

		twistPivot.RotateY(twistInput);
		pitchPivot.RotateX(pitchInput);

		Vector3 pitch_rotation = new Vector3(
			Mathf.Clamp(
				pitchPivot.Rotation.X,
				Mathf.DegToRad(-30),
				Mathf.DegToRad(30)
				), 
		pitchPivot.Rotation.Y, 
		pitchPivot.Rotation.Z);

		pitchPivot.Rotation = pitch_rotation;
		twistInput = 0.0F;
		pitchInput = 0.0F;	
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		base._UnhandledInput(@event);
		if (@event is InputEventMouseMotion mouseMotion){
			if (Input.MouseMode == Input.MouseModeEnum.Captured){
				twistInput =- mouseMotion.Relative.X * mouseSensitivity;
				pitchInput =- mouseMotion.Relative.Y * mouseSensitivity;
			}
		}
	}
}
