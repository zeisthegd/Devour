using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizStateMachine
{
	class StateMachine
	{
		#region States
		WizState idle;
		WizState run;
		WizState attack;

		WizState wizState;//current state
		#endregion

		#region Wiz's Fields
		Wiz wiz;


		#endregion

		Animation.AnimationControl animationControl = new Animation.AnimationControl();
		bool isAttacking = false;
		int runSpeed = 100;

	   public Animation.AnimationControl AnimationControl
		{
			get { return animationControl; }
		}
			

		public StateMachine(Wiz newWiz)
		{
			idle = new Idle(this);
			run = new Run(this);
			attack = new Attack(this);

			this.wiz = newWiz;


			wizState = idle;

			
		}

		public void SetWizState(WizState newWizState)
		{
			this.wizState = newWizState;
		}

		public void HandleInput()
		{
			animationControl.ChangeAnimationDirection();
			wizState.HandleInput(wiz);
		}


		public WizState GetRunState() { return run; }
		public WizState GetIdleState() { return idle; }
		public WizState GetAttackState() 
		{
			isAttacking = true;
			return attack; 
		}

		public int GetRunSpeed() { return runSpeed; }

		public bool IsAttacking
		{
			get { return isAttacking; }
			set { isAttacking = value; }
		}

		

	}
}
