using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizStateMachine
{
	class Transforming : WizState
	{

		public Transforming(StateMachine newStateMachine) : base(newStateMachine)
		{
		}
		public override void HandleInput()
		{
			ChangeActionAlgorithmAndForm(wiz);
			PlayAnimation();
			DoneTransforming();
		}
		public override void PlayAnimation()
		{
			wiz.AnimationPlayer.Play("transform");//change later
		}
		private void ChangeActionAlgorithmAndForm(Wiz wiz)
		{
			wiz.FormManager.ChangeWizForm(wiz);
		}
		private void DoneTransforming()
		{
			if (wiz.AnimationPlayer.CurrentAnimation != "transform")
				ChangeToIdle();
		}
	}
}
