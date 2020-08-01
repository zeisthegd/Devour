using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobStateMachine
{
	public class StateMachine
	{
		#region States
		IMobState patrol;
		IMobState attack;
		IMobState chase;
		IMobState die;
		IMobState hooked;

		IMobState mobState;
		#endregion

		#region Mob
		public Mob mob;

		#endregion

		Animation.AnimationControl animationControl = new Animation.AnimationControl();
		bool isAttacking = false;
		bool isHookingMob = false;
		int runSpeed = 100;
		float distanceToAttack = 100;

		public Animation.AnimationControl AnimationControl
		{
			get { return animationControl; }
		}

		public StateMachine(Mob newMob)
		{
			patrol = new GeneralStates.Patrol(this);
			attack = new GeneralStates.Attack(this);
			chase = new GeneralStates.Chase(this);
			hooked = new GeneralStates.Hooked(this);

			this.mob = newMob;

			mobState = patrol;
		}

		public void Action()
		{
			animationControl.ChangeMobAnimationDirection(this.mob);
			mobState.AutoPilot(this.mob);
		}

		public void SetMobState(IMobState newMobState)
		{
			this.mobState = newMobState;
		}

		public void ChangeToPatrol() { this.mobState = GetPatrolState(); }
		public void ChangeToChase() { this.mobState = GetChaseState(); }
		public void ChangeToAttack()
		{
			this.mobState = GetAttackState();
		}
		public void ChangeToHooked()
		{
			if (isHookingMob)
				this.mobState = GetHookedState();
		}

		public IMobState GetHookedState() { return hooked; }
		public IMobState GetPatrolState() { return patrol; }
		public IMobState GetChaseState() { return chase; }
		public IMobState GetAttackState() { return attack; }

		public bool IsAttacking
		{
			get { return isAttacking; }
			set { isAttacking = value; }
		}
		public bool IsHookingMob
		{
			get { return isHookingMob; }
			set { isHookingMob = value; }
		}
	}
}
