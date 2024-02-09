using Godot;
using System;
using System.Collections.Generic;

public partial class EntityConfig : Node
{
	RigidBody3D entity;
	ConfigFile entityConfig;
	static string dirPath = "..\\DeflectIO\\Configs\\";

	/// <summary>
	/// Returns loaded entity config, WARNING, CHANGES HAVENT BEEN APPLIED YET
	/// </summary>
	/// <param name="path">Conf path</param>
	/// <returns>Returns the loaded config file</returns>
	public ConfigFile LoadConfig(string path)
	{
		ConfigFile p_conf = new ConfigFile();
		var err = p_conf.Load(dirPath + path);

		if (err == Error.Ok)
		{
			return p_conf;
		}
		return null;
	}

	/// <summary>
	/// Save config at file specified, default is Configs
	/// </summary>
	/// <param name="path">Specify path to save</param>
	/// <returns>Bool status</returns>
	public bool SaveConfig(string path)
	{
		if (entityConfig is not null)
		{
			var err = entityConfig.Save(dirPath + path);

			if (err == Error.Ok)
			{
				return true;
			}
			return false;
				
		}
		return false;
	}

	/// <summary>
	/// Create a config file for the entity
	/// </summary>
	/// <returns>ConfigFile</returns>
	public ConfigFile CreateConfig()
	{
		if (entityConfig is null)
		{
			entityConfig = new ConfigFile();
			return entityConfig;
		}
		return null;
	}

	/// <summary>
	/// Adds a parameter to a ConfigFile
	/// </summary>
	/// <param name="conf">ConfigFile to add property</param>
	/// <param name="section">Section to add property</param>
	/// <param name="key">Value key</param>
	/// <param name="value">Value</param>
	/// <returns></returns>
	public ConfigFile AddProperty(ConfigFile conf, string section, string key, Variant value)
	{
		if (conf is not null)
		{
			conf.SetValue(section, key, value);
		}
		return null;
	}

	public ConfigFile AddProperties(ConfigFile conf, string section, Godot.Collections.Dictionary<string, Variant> stats)
	{
		foreach (KeyValuePair<string, Variant> stat in stats)
		{
			conf.SetValue(section, stat.Key, stat.Value);
		}
		return null;
	}

	/// <summary>
	/// Set/Get entity configuration file
	/// </summary>
	public ConfigFile entityConfiguration
    {
		get => entityConfig;
		set => entityConfig = value;

    }

	/// <summary>
	/// Set/Get entity object
	/// </summary>
	public RigidBody3D entityObject
	{
		get => entity;
		set => entity = value;
	}

	/// <summary>
	/// Hard code entity object (in case of bugs)
	/// </summary>
	/// <param name="r">Scene Root</param>
	/// <param name="entityName">String entity name</param>
	/// <returns>RibigBody entity</returns>
	public RigidBody3D HardcodeEntity(Node r, string entityName)
	{
		var tools = GetNode("/root/GGlobalTools") as GlobalTools;
		entity = (RigidBody3D) tools.Get_Node_From_Root(r, entityName);

		return entity is not null? entity : null;
	}
}
