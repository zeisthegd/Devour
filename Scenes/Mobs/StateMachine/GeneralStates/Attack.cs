using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace MobStateMachine
{
	class Attack : MobState
	{
		public Attack(StateMachine newStateMachine):base(newStateMachine)
		{		
		}

		public override void AutoPilot()
		{
			base.AutoPilot();
		}

		public override void PlayAnimation()
		{
			stateMachine.AnimationControl.ChangeAnimation(mob.AnimationPlayer, "idle");
		}

		public override void RunOutOfHealth()
		{
			//change state
			//die
		}

		public override void SeeWiz()
		{
		}

		public override void WizOutOfSight()
		{
			if (!mob.WizEnteredAttackZone)
				ChangeToPatrol();
		}
    }
}
