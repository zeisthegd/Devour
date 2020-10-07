using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizStateMachine
{
    public abstract class WizState : IWizState
    {
        protected StateMachine stateMachine;
        protected Wiz wiz;

        public WizState(StateMachine newStateMachine)
        {
            stateMachine = newStateMachine;
            wiz = stateMachine.Wiz;
        }

        public abstract void HandleInput();

        public virtual void PlayAnimation()
        {
            throw new NotImplementedException();
        }

        public virtual void PressAttack()
        {
            throw new NotImplementedException();
        }

        public virtual void PressDown()
        {
            throw new NotImplementedException();
        }

        public virtual void PressLeft()
        {
            throw new NotImplementedException();
        }

        public virtual void PressRight()
        {
            throw new NotImplementedException();
        }

        public virtual void PressSpecial()
        {
            throw new NotImplementedException();
        }

        public virtual void PressUp()
        {
            throw new NotImplementedException();
        }

        protected void ChangeToIdle()
        {
            stateMachine.SetWizState(stateMachine.GetIdleState());
        }
        protected void ChangeToAttack()
        {
            stateMachine.SetWizState(stateMachine.GetAttackState());
        }
        protected void ChangeToRun()
        {
            stateMachine.SetWizState(stateMachine.GetRunState());
        }
        protected void ChangeToHook()
        {
            stateMachine.SetWizState(stateMachine.GetHookingState());
        }
        protected void ChangeToTransform()
        {
            stateMachine.SetWizState(stateMachine.GetTransformState());
        }
    }
}
