using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizStateMachine
{
	class Transforming : IWizState
	{
		StateMachine stateMachine;

		public Transforming(StateMachine newStateMachine)
		{
			stateMachine = newStateMachine;
		}
		public void HandleInput(Wiz wiz)
		{
			ChangeActionAlgorithmAndForm(wiz);
			PlayAnimation(wiz);
			ChangeToIdle(wiz);
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

		public void PressSpecial(Wiz wiz)
		{

		}
		public void PlayAnimation(Wiz wiz)
		{
			wiz.AnimationPlayer.Play("transform");//change later
		}
		private void ChangeActionAlgorithmAndForm(Wiz wiz)
		{
			GD.Print("Changed");

			wiz.FormManager.ChangeWizForm(wiz);
		}
		private void ChangeToIdle(Wiz wiz)
		{
			if (wiz.AnimationPlayer.CurrentAnimation != "transform")
				stateMachine.ChangeToIdle();
		}
	}
}
