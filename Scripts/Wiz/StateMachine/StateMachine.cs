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
        Wiz wiz;
        #region States
        WizState idle;
        WizState run;
        WizState attack;
        WizState hooking;
        WizState transform;

        WizState wizState;//current state
        #endregion

        Animation.AnimationControl animationControl = new Animation.AnimationControl();
        bool isAttacking = false;
        bool isHooking = false;

        int runSpeed = 100;

       

        public StateMachine(Wiz newWiz)
        {
            this.wiz = newWiz;

            idle = new Idle(this);
            run = new Run(this);
            attack = new Attack(this);
            hooking = new Hooking(this);
            transform = new Transforming(this);      
            wizState = idle;
        }

        public void SetWizState(WizState newWizState)
        {
            this.wizState = newWizState;
        }

        public void HandleInput()
        {
            animationControl.ChangeWizAnimationDirection();
            wizState.HandleInput();
        }


        public WizState GetRunState() { return run; }
        public WizState GetIdleState() { return idle; }
        public WizState GetAttackState()
        {
            isAttacking = true;
            return attack;
        }
        public WizState GetHookingState() { return hooking; }
        public WizState GetTransformState() { return transform; }
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
        public Animation.AnimationControl AnimationControl
        {
            get { return animationControl; }
        }
        public Wiz Wiz { get => wiz; }

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
