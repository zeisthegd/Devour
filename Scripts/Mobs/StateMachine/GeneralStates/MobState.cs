using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobStateMachine
{
    public class MobState : IMobState
    {
        protected StateMachine stateMachine;
        protected Mob mob;

        public MobState(StateMachine newStateMachine)
        {
            this.stateMachine = newStateMachine;
            mob = stateMachine.Mob;
        }
        public virtual void AutoPilot() 
        {
            SeeWiz();
            WizOutOfSight();
            RunOutOfHealth();
            GetHooked();
            PlayAnimation();
        }

        public virtual void PlayAnimation() { }
        public virtual void RunOutOfHealth() { }
        public virtual void SeeWiz() { }
        public virtual void WizOutOfSight() { }
        public virtual void GetHooked() 
        {
            if (stateMachine.IsBeingHooked)
                ChangeToHooked();
        }


        protected void ChangeToPatrol()
        {
            stateMachine.SetMobState(stateMachine.PatrolState);
        }
        protected void ChangeToChase()
        {
            stateMachine.SetMobState(stateMachine.ChaseState);
        }
        protected void ChangeToHooked()
        {
            stateMachine.SetMobState(stateMachine.HookedState);
        }
        protected void ChangeToAttack()
        {
            stateMachine.SetMobState(stateMachine.AttackState);
            if (mob.WizEnteredAttackZone)
                mob.AttackStrategy.WindUp();
        }
    }
}
