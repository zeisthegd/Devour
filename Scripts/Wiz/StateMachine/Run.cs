using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizStateMachine
{
	class Run : WizState
	{
		StateMachine stateMachine;
		Vector2 tempVec;

		int runSpeed;

		public Run(StateMachine newStateMachine)
		{
			stateMachine = newStateMachine;
			runSpeed = stateMachine.GetRunSpeed();
		}
		public void HandleInput(Wiz wiz)
		{
			GD.Print("run");
			wiz.Velocity = new Vector2();

			PressUp(wiz);
			PressDown(wiz);
			PressRight(wiz);
			PressLeft(wiz);

			PlayAnimation(wiz);

			PressAttack(wiz);

			SetWizVelocity(wiz);
			
			ChangeToIdle(wiz);


		}

		public void PressAttack(Wiz wiz)
		{
			if (Input.IsActionJustPressed("ui_attack"))
				ChangeToAttack(wiz);
		}

		#region Run Algorhithm
		public void PressDown(Wiz wiz)
		{
			if (Input.IsActionPressed("ui_down"))
				RunDown(wiz);
		}

		public void PressLeft(Wiz wiz)
		{
			if (Input.IsActionPressed("ui_left"))
				RunLeft(wiz);
		}

		public void PressRight(Wiz wiz)
		{
			if (Input.IsActionPressed("ui_right"))
				RunRight(wiz);
		}

		public void PressUp(Wiz wiz)
		{
			if (Input.IsActionPressed("ui_up") )
				RunUp(wiz);
		}

		private void SetWizVelocity(Wiz wiz)
		{
			if(!stateMachine.IsAttacking)
				wiz.Velocity = wiz.Velocity.Normalized() * stateMachine.GetRunSpeed();
		}

		private void RunLeft(Wiz wiz)
		{
			tempVec = wiz.Velocity;
			tempVec.x -= 1;
			wiz.Velocity = tempVec;
		}
		private void RunRight(Wiz wiz)
		{
			tempVec = wiz.Velocity;
			tempVec.x += 1;
			wiz.Velocity = tempVec;
		}
		private void RunUp(Wiz wiz)
		{
			tempVec = wiz.Velocity;
			tempVec.y -= 1;
			wiz.Velocity = tempVec;
		}
		private void RunDown(Wiz wiz)
		{
			tempVec = wiz.Velocity;
			tempVec.y += 1;
			wiz.Velocity = tempVec;
		}
		#endregion

		public void PlayAnimation(Wiz wiz)
		{
			stateMachine.AnimationControl.ChangeAnimation(wiz.AnimationPlayer, "run");
		}

		private void ChangeToIdle(Wiz wiz)
		{
			if (wiz.Velocity == Vector2.Zero)
				stateMachine.SetWizState(stateMachine.GetIdleState());
		}

		private void ChangeToAttack(Wiz wiz)
		{
			runSpeed = 0;
			wiz.AttackTimer.Start();
			stateMachine.SetWizState(stateMachine.GetAttackState());
		}



	}
}
