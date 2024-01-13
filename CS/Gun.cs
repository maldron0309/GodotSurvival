using Godot;
using System;

public partial class Gun : Area2D
{
    // Assuming ShootingPoint is a Node2D object representing the point where bullets are fired.
    private Node2D ShootingPoint;

    public override void _Ready()
    {
        // Assuming ShootingPoint is a child node of the current node.
        ShootingPoint = GetNode<Node2D>("WeaponPivot/Pistol/ShootingPoint");
    }

    public override void _Process(double delta)
    {
        var enemiesInRange = GetOverlappingBodies();

        if (enemiesInRange.Count > 0)
        {
            var targetEnemy = (Node2D)enemiesInRange[0];
            LookAt(targetEnemy.GlobalPosition);
        }
    }

    public void Shoot()
    {
        var BULLET = ResourceLoader.Load<PackedScene>("res://bullet.tscn");
        var newBullet = (Node2D)BULLET.Instantiate();
        newBullet.GlobalPosition = ShootingPoint.GlobalPosition;
        ShootingPoint.AddChild(newBullet);
    }

	public void OnTimerTimeout()
	{
		Shoot();
	}
}
