using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizStateMachine
{
	public class StateMachine
	{
		#region States
		IWizState idle;
		IWizState run;
		IWizState attack;
		IWizState hooking;
		IWizState transform;

		IWizState wizState;//current state
		#endregion

		#region Wiz's Fields
		Wiz wiz;


		#endregion

		Animation.AnimationControl animationControl = new Animation.AnimationControl();
		bool isAttacking = false;
		bool isHooking = false;

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
			hooking = new Hooking(this);
			transform = new Transforming(this);

			this.wiz = newWiz;


			wizState = idle;

			
		}

		public void SetWizState(IWizState newWizState)
		{
			this.wizState = newWizState;
		}

		public void HandleInput()
		{
			animationControl.ChangeWizAnimationDirection();
			wizState.HandleInput(wiz);
		}


		public IWizState GetRunState() { return run; }
		public IWizState GetIdleState() { return idle; }
		public IWizState GetAttackState() 
		{
			isAttacking = true;
			return attack; 
		}
		public IWizState GetHookingState() { return hooking; }
		public IWizState GetTransformState() { return transform; }
		public int GetRunSpeed() { return runSpeed; }

		public bool IsAttacking
		{
			get { return isAttacking; }
			set { isAttacking = value; }
		}

		public bool IsHooking
		{
			get { return isHooking; }
			set { isHooking = value; }
		}

		public void ChangeToIdle()
		{
			SetWizState(GetIdleState());
		}
		public void ChangeToAttack()
		{
			SetWizState(GetAttackState());
		}
		public void ChangeToRun()
		{
			SetWizState(GetRunState());
		}
		public void ChangeToHook()
		{
			SetWizState(GetHookingState());
		}
		public void ChangeToTransform()
		{
			SetWizState(GetTransformState());
		}

	}
}
