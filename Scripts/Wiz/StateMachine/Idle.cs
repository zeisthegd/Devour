using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace WizStateMachine
{
	class Idle :WizState
	{
		public Idle(StateMachine newStateMachine) : base(newStateMachine)
		{
		}
		public override void HandleInput()
		{
			wiz.Velocity = new Vector2();
			PressDown();
			PressLeft();
			PressRight();
			PressUp();
			PressAttack();
            PressSpecial();
			PlayAnimation();
		}

		public override void PressAttack()
		{
			if (Input.IsActionJustPressed("attack") )
			{
				//wiz.CurrentForm.DoAttack();
				if (wiz.CanUseHook)
					wiz.FormAlgorithm.DoAttack();
				//else
				//	ChangeToAttack(wiz);
			}
		}
		public override void PressSpecial()
		{
			if (Input.IsActionJustPressed("special"))
				wiz.FormAlgorithm.UseSpecial();
		}

		public override void PressDown()
		{
			if (Input.IsActionPressed("ui_down"))
				ChangeToRun();
		}

		public override void PressLeft()
		{
			if (Input.IsActionPressed("ui_left"))
				ChangeToRun();

		}

		public override void PressRight()
		{
			if (Input.IsActionPressed("ui_right"))
				ChangeToRun();

		}

		public override void PressUp()
		{
			if (Input.IsActionPressed("ui_up"))
				ChangeToRun();

		}

		public override void PlayAnimation()
		{
			stateMachine.AnimationControl.ChangeAnimation(wiz.AnimationPlayer, "idle");
		}
	}
}
