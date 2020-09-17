using Godot;
using System;

public class Camera : Camera2D
{

	Wiz wiz;
	public override void _Ready()
	{
		wiz = (Wiz)GetParent().GetNode("Wiz") ;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		this.GlobalPosition = wiz.GlobalPosition;

	}

	Vector2 RoundDownPosition(Vector2 vectorToRound)
	{
		int newRoundedX = (int)vectorToRound.x;
		int newRoundedY = (int)vectorToRound.y;

		Vector2 newRoundedVec = new Vector2(newRoundedX, newRoundedY);

		return newRoundedVec;
	}
}
