using Godot;
using System;
using AttackTypes;
using MobStateMachine;
using AISystem;
using Utility;
using Devour;

public class Mob : Area2D
{
	protected string wizForm;
	protected string mobName;

	protected byte spriteSize;
	protected AnimationPlayer animationPlayer;
	protected Vector2 velocity;


	protected StateMachine stateMachine;
	protected Attacks attackStrategy;

	protected Area2D rangeToChase;
	protected byte moveSpeed = 5;
	protected byte hookedSpeed = 3;

	protected PatrolSystem patrolSystem;


	protected bool isAttacking;

	protected bool wizEnteredAttackZone = false;
	protected bool canAttack = true;

	protected Wiz wiz;

	public override void _Ready()
	{
		animationPlayer = (AnimationPlayer)GetNode("animationPlayer");
		patrolSystem = (PatrolSystem)GetNode("PatrolSystem");
		stateMachine = new StateMachine(this);
		wiz = (Wiz)GetParent().GetNode("Wiz");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{

		if (patrolSystem == null)
			GD.Print("NULL");
		stateMachine.Action();

	}
	public override void _PhysicsProcess(float delta)
	{
		base._PhysicsProcess(delta);
		Position += velocity * moveSpeed;
	}


	public void HookToWiz()
	{
		Velocity = DirectionToWiz().Normalized() * hookedSpeed ;
	}

	private Vector2 DirectionToWiz()
	{
		return (wiz.Position - this.GlobalPosition);
	}

	private void ChangeWizFormInformation(string newWizForm)
	{
		wiz.FormManager.ChangeNextForm(FormManager.Form.Kwissi);
	}

	private void _on_Mob_area_entered(Area2D area)
	{
		if (GroupCheck.IsInTheHook(area))
		{
			stateMachine.IsBeingHooked = true;
		}
	}
	private void _on_Mob_body_entered(KinematicBody2D body)
	{
		if (GroupCheck.IsInWiz(body))
		{

			if (!stateMachine.IsBeingHooked)
				GD.Print("wiz hp -= 1 ");
			else
			{
				ChangeWizCurrentlyAbsorbedMobIcon();
				ChangeFormManagerNextForm();
				QueueFree();
			}
			//TODO something else instead of queuefree
		}
	}
	private void ChangeWizCurrentlyAbsorbedMobIcon()
	{
		if (stateMachine.IsBeingHooked)
			wiz.AbsorbedMobIconDisplayer.SetMobName(mobName);
	}
	public virtual void ChangeFormManagerNextForm()
	{

	}

	private void _on_attackRange_body_entered(KinematicBody2D body)
	{
		if (GroupCheck.IsInWiz(body))
		{
			wizEnteredAttackZone = true;
		}
	}

	private void _on_attackRange_body_exited(KinematicBody2D body)
	{
		if (GroupCheck.IsInWiz(body))
		{
			wizEnteredAttackZone = false;
		}
	}


	public Vector2 Velocity
	{
		get { return velocity; }
		set { velocity = value; }
	}

	public byte SpriteSize
	{
		get { return spriteSize; }
		set { spriteSize = value; }
	}

	public AISystem.PatrolSystem PatrolSystem
	{
		get { return patrolSystem; }
	}
	public AnimationPlayer AnimationPlayer
	{
		get { return animationPlayer; }
	}

	public Attacks AttackStrategy
	{
		get { return attackStrategy; }
	}

	public bool CanAttack
	{
		get { return canAttack; }
	}
	public bool WizEnteredAttackZone
	{
		get { return wizEnteredAttackZone; }
	}

}










