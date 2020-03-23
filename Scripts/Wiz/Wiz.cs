using Godot;
using System;
using WizStateMachine;

public class Wiz : KinematicBody2D
{
	StateMachine stateMachine;

	Timer attackDuration;
	AnimationPlayer animationPlayer = new AnimationPlayer();
	Vector2 velocity;

	public override void _Ready()
	{	
		animationPlayer = (AnimationPlayer)GetNode("animationPlayer");
		attackDuration = (Timer)GetNode("attackDuration");
		stateMachine = new StateMachine(this);
	}

	public override void _PhysicsProcess(float delta)
	{
		
		velocity = MoveAndSlide(velocity);
	}


	public override void _Process(float delta)
	{
		//GD.Print(stateMachine.IsAttacking);
		ManageStateMachine();
	}

	#region Properties
	public AnimationPlayer AnimationPlayer
	{
		get { return animationPlayer; }
	}

	public Timer AttackTimer
	{
		get { return attackDuration; }
	}

	public Vector2 Velocity
	{
		get { return velocity; }
		set { velocity = value; }
	}
	#endregion


	private void ManageStateMachine()
	{
		stateMachine.HandleInput();
	}
	private void _on_attackDuration_timeout()
	{
		AttackTimer.WaitTime = 0.3F;
		stateMachine.IsAttacking = false;
	}
}



