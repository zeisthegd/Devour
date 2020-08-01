using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace GeneralStates
{
	class Attack : MobStateMachine.IMobState
	{
		MobStateMachine.StateMachine stateMachine;

		public Attack(MobStateMachine.StateMachine newStateMachine)
		{
			stateMachine = newStateMachine;

		}

		public void AutoPilot(Mob mob)
		{

			SeeWiz(mob);
			WizOutOfSight(mob);
			PlayAnimation(mob);

			stateMachine.ChangeToHooked();
		}

		public void PlayAnimation(Mob mob)
		{
			stateMachine.AnimationControl.ChangeAnimation(mob.AnimationPlayer, "idle");
		}

		public void RunOutOfHealth(Mob mob)
		{
			//change state
			//die
		}

		public void SeeWiz(Mob mob)
		{
			mob.AttackStrategy.Attack();
		}

		public void WizOutOfSight(Mob mob)
		{
			//change to patrol
			if (!mob.WizInAttack)
				stateMachine.ChangeToPatrol();
		}
	}
}
