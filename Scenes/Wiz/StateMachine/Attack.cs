using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizStateMachine
{
	class Attack : WizState
	{
		public Attack(StateMachine newStateMachine):base(newStateMachine)
		{                    
		}
		public override void HandleInput()
		{
			PlayAnimation();
			NotAttacking();
		}
		public override void PressUp()
		{
			
		}

		public override void PressDown()
		{
			
		}

		public override void PressLeft()
		{
		   
		}

		public override void PressRight()
		{
			
		}

		public override void PressAttack()
		{
			wiz.FormAlgorithm.DoAttack();
		}
		public override void PressSpecial()
		{
			wiz.FormAlgorithm.UseSpecial();
		}
		public override void PlayAnimation()
		{
		}
		private void NotAttacking()
		{
			if (stateMachine.IsAttacking == false)
				ChangeToIdle();

		}
	}
}
