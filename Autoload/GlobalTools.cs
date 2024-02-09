using Godot;
using System;

public partial class GlobalTools : Node
{

	/// <summary>
	/// Get Node or null by searching from root
	/// </summary>
	/// <param name="root">Scene root</param>
	/// <param name="nodeName">String node name</param>
	/// <returns>Returns node or null</returns>
	public Node Get_Node_From_Root(Node root, string nodeName)
	{
		return GetTree().Root.GetNodeOrNull(root + "/" + nodeName);
	}

	
	/// <summary>
	/// Find node in current scene by iterating children or node
	/// </summary>
	/// <param name="root">Root or father</param>
	/// <param name="nodeName">String node name</param>
	/// <returns>Node or null</returns>
	public Node Get_Node_In_Scene(Node root, string nodeName)
	{
		foreach (var child in root.GetChildren(true))
		{
			if (child.Name == nodeName)
			{
				return child;
			}
		}
		return null;
	}

	
	/// <summary>
	/// Loads scene
	/// </summary>
	/// <param name="scenePath">Scene path</param>
	/// <returns>Resource scene</returns>
	public Resource Load_Scene(string scenePath)
	{
		var scene = GD.Load(scenePath); 
		return scene;
	}
}
