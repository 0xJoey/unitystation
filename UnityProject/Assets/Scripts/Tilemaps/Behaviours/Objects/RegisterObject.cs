﻿using System.Text.RegularExpressions;
using UnityEngine;

/// <summary>
/// <see cref="RegisterTile"/> for an object, adds additional logic to
/// make object passable / impassable.
/// </summary>
[ExecuteInEditMode]
public class RegisterObject : RegisterTile
{
	public bool AtmosPassable = true;
	public bool Passable = true;

	public override bool IsPassable(Vector3Int from, bool isServer)
	{
		return Passable || (isServer ? LocalPositionServer == TransformState.HiddenPos : LocalPositionClient == TransformState.HiddenPos );
	}

	public override bool IsPassable(bool isServer)
	{
		return Passable || (isServer ? LocalPositionServer == TransformState.HiddenPos : LocalPositionClient == TransformState.HiddenPos );
	}

	public override bool IsAtmosPassable(Vector3Int from, bool isServer)
	{
		return AtmosPassable || (isServer ? LocalPositionServer == TransformState.HiddenPos : LocalPositionClient == TransformState.HiddenPos );
	}

	#region UI Mouse Actions

	public void OnHoverStart()
	{
		//thanks stack overflow!
		Regex r = new Regex(@"
                (?<=[A-Z])(?=[A-Z][a-z]) |
                 (?<=[^A-Z])(?=[A-Z]) |
                 (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);

		string tmp = r.Replace(name, " ");
		UIManager.SetToolTip = tmp;
	}

	public void OnHoverEnd()
	{
		UIManager.SetToolTip = "";
	}

	#endregion
}