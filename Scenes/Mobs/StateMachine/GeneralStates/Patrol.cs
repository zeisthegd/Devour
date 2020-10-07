using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AISystem;
using Godot;

namespace MobStateMachine
{
	class Patrol : MobState
	{
		public Patrol(StateMachine newStateMachine): base(newStateMachine)
		{
		}
		public override void AutoPilot()
		{
			base.AutoPilot();
		}

		public override void PlayAnimation()
		{
			if(mob.Velocity != Vector2.Zero)
				stateMachine.AnimationControl.ChangeAnimation(mob.AnimationPlayer,"patrol");
			else stateMachine.AnimationControl.ChangeAnimation(mob.AnimationPlayer, "idle");
		}

		public override void RunOutOfHealth()
		{
			//if mob health <=0 change to die
			//die
		}

		public override void SeeWiz()
		{
			if (mob.WizEnteredAttackZone)
				ChangeToAttack();
		}

		public override void WizOutOfSight()
		{					
			mob.PatrolSystem.DoPatrol(mob);
		}

	}
}
