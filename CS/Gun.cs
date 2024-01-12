using Godot;
using System;

public partial class Gun : Area2D
{

	public override void _Process(double delta)
	{
		var enemiesInRange = GetOverlappingBodies();

		if (enemiesInRange.Count > 0)
		{
			var targetEnemy = enemiesInRange[0];
			LookAt(targetEnemy.GlobalPosition);
		}
	}

	public void Shoot()
	{
		var BULLET = ResourceLoader.Load<PackedScene>("res://bullet.tscn");

	}
}


