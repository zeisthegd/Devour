using Godot;
using System;
using WizStateMachine;
using WizHook;
using Devour;

public class Wiz : KinematicBody2D
{
	StateMachine stateMachine;

	Timer attackDuration;
	AnimationPlayer animationPlayer;
	Vector2 velocity;

	FormManager formManager;

	bool canUseHook = true;

	Hook hook;

	TransformMobIcon absorbedmobIconDisplayer;

	public override void _Ready()
	{
		formManager = new FormManager();
		absorbedmobIconDisplayer = (TransformMobIcon)GetNode("absorbedmobIconDisplayer");
		attackDuration = (Timer)GetNode("attackDuration");
		stateMachine = new StateMachine(this);
		formManager.CreateNormalWizForm(this);
	}

	public override void _PhysicsProcess(float delta)
	{
		velocity = MoveAndSlide(velocity);
	}


	public override void _Process(float delta)
	{
		GD.Print(formManager.NextFormEnum.ToString());
		ManageStateMachine();
	}

	#region Properties
	public AnimationPlayer AnimationPlayer
	{
		get { return animationPlayer; }
		set { this.animationPlayer = value; }
	}
	public StateMachine WizStateMachine
	{
		get { return stateMachine; }
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
	public Hook Hook
	{
		get { return hook; }
		set { hook = value; }

	}
	public bool CanUseHook
	{
		get { return canUseHook; }

	}
	public FormManager FormManager
	{
		get { return formManager; }
	}
	public WizForms FormAlgorithm
	{
		get { return formManager.FormAlgorithm; }
	}
	public TransformMobIcon AbsorbedMobIconDisplayer
	{
		get { return absorbedmobIconDisplayer; }
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



