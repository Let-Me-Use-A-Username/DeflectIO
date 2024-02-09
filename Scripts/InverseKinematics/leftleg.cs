using Godot;
using System;

public partial class leftleg : SkeletonIK3D
{
	Node3D target;
	Skeleton3D skeleton;

	public override void _Ready()
	{
		target = new Node3D();
		skeleton = GetParent<Skeleton3D>();

		Start();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector3 movement_input = Vector3.Zero;
		movement_input.X = Input.GetAxis("left", "right");
		movement_input.Z = Input.GetAxis("forward", "backward");


		int footId = skeleton.FindBone("LeftFoot");

		Vector3 footPos = skeleton.GetBonePosePosition(footId);
		target.Position = footPos * movement_input * 100;

		skeleton.SetBonePosePosition(footId, target.GlobalPosition);
	}
}