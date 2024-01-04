using Godot;
using System;

public partial class Mob : Info
{
Node2D player;

public override void _Ready()
{
    player = GetNode<Node2D>("../Player");

}
public override void _PhysicsProcess(double delta)
{
   mob((float)delta);
}
 
/// <summary>
///  Mob follow player
/// </summary>
/// <param name="delta"></param>
private void mob(float delta)
{
    float moveAmount = (float)(speed * delta);
   
   Vector2 dir = (player.Position - Position).Normalized();
   Position += dir * moveAmount;
}
}