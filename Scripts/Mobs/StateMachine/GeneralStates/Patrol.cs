using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AISystem;
using Godot;

namespace GeneralStates
{
	class Patrol : MobStateMachine.IMobState
	{
		MobStateMachine.StateMachine stateMachine;

		public Patrol(MobStateMachine.StateMachine newStateMachine)
		{
			stateMachine = newStateMachine;

		}
		public void AutoPilot(Mob mob)
		{
			SeeWiz(mob);
			WizOutOfSight(mob);
			RunOutOfHealth(mob);
			PlayAnimation(mob);

			stateMachine.ChangeToHooked();
		}

		public void PlayAnimation(Mob mob)
		{
			if(mob.Velocity != Vector2.Zero)
				stateMachine.AnimationControl.ChangeAnimation(mob.AnimationPlayer,"patrol");
			else stateMachine.AnimationControl.ChangeAnimation(mob.AnimationPlayer, "idle");
		}

		public void RunOutOfHealth(Mob mob)
		{
			//if mob health <=0 change to die
			//die

		}

		public void SeeWiz(Mob mob)
		{
			if (mob.WizInAttack)
				stateMachine.ChangeToAttack();
		}

		public void WizOutOfSight(Mob mob)
		{
			if (!mob.WizInAttack)						
				mob.PatrolSystem.DoPatrol(mob);
		}

	}
}
