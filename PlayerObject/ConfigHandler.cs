using Godot;
using System;

public partial class ConfigHandler : Node
{
	private static EntityConfig config;
	private static GlobalTools tools;
	private RigidBody3D player;

	public override void _Ready()
    {
		config = GetNode<EntityConfig>("/root/GEntityConfig");
		tools = GetNode<GlobalTools>("/root/GGlobalTools");
    }

    public void SetPlayerFromRoot(Node r, string playerName)
    {
        player = (RigidBody3D) tools.Get_Node_From_Root(r, playerName);

		config.entityObject = player;
    }

	public void SetPlayerFromNode(RigidBody3D p)
	{
		player = p;

		config.entityObject = p;
	}

	/// <summary>
	/// Initializes a default config file for the player with all of the parameters including health, speed, movement options etc.
	/// </summary>
	/// <param name="p">Player node to be specified for the config file</param>
	/// <param name="applyChanges">Boolean parameter to apply the changes</param>
    public void InitializeDefaultConfig(RigidBody3D p, bool applyChanges)
	{
		SetPlayerFromNode(p);

		ConfigFile player_conf = config.CreateConfig();
		config.AddProperty(player_conf, "Player_Movement", "linear_damp", 3);
		config.AddProperty(player_conf, "Player_Movement", "lock_rotation", true);
		config.AddProperty(player_conf, "Player_Stats", "health", 100);
		config.AddProperty(player_conf, "Player_Stats", "speed", 1200.0);
		config.SaveConfig("player_conf.cfg");
		
		if (applyChanges)
		{
			player_conf = config.LoadConfig("player_conf.cfg");
			var lin_damp = player_conf.GetValue("Player_Movement", "linear_damp");
			var lock_rotation = player_conf.GetValue("Player_Movement", "lock_rotation");
			
			player.LinearDamp = (float)lin_damp;
			player.LockRotation = (bool)lock_rotation;
		}
	}


	public void AddProperty(string section, string key, Variant value)
	{
		if (config is not null)
		{
			config.AddProperty(config.entityConfiguration, section, key, value);
			config.SaveConfig("player_config.cfg");
		}
	}

	public void AddProperties(string section, Godot.Collections.Dictionary<string, Variant> stats)
	{
		if (config is not null)
		{
			config.AddProperties(config.entityConfiguration, section, stats);
			config.SaveConfig("player_config.cfg");
		}
	}


	public void LoadPlayerConfig()
	{
		var p_conf = config.LoadConfig("player_config.cfg");
		
		if (p_conf is null)
		{
			p_conf = config.CreateConfig();
		}

		config.entityConfiguration = p_conf;
	}

}
