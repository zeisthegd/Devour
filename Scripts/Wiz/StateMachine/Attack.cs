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
		StateMachine stateMachine;

		public Attack(StateMachine newStateMachine)
		{                    
			stateMachine = newStateMachine;
		}
		public void HandleInput(Wiz wiz)
		{
			//GD.Print("attack");
			PlayAnimation(wiz);
			ChangeToIdle();
		}
		

		public void PressUp(Wiz wiz)
		{
			
		}

		public void PressDown(Wiz wiz)
		{
			
		}

		public void PressLeft(Wiz wiz)
		{
		   
		}

		public void PressRight(Wiz wiz)
		{
			
		}

		public void PressAttack(Wiz wiz)
		{
			stateMachine.SetWizState(stateMachine.GetAttackState());
		}
		public void PlayAnimation(Wiz wiz)
		{
			wiz.AnimationPlayer.Play("attackDown");//change later
		}
		private void ChangeToIdle()
		{
			if(stateMachine.IsAttacking == false)
				stateMachine.SetWizState(stateMachine.GetIdleState());

		}
	}
}
