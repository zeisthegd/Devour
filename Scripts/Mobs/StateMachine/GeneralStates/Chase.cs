using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStates
{
    class Chase : MobStateMachine.IMobState
    {
        MobStateMachine.StateMachine stateMachine;

        public Chase(MobStateMachine.StateMachine newStateMachine)
        {
            stateMachine = newStateMachine;

        }

        public void AutoPilot(Mob mob)
        {
            throw new NotImplementedException();
        }

        public void PlayAnimation(Mob mob)
        {
            throw new NotImplementedException();
        }

        public void RunOutOfHealth(Mob mob)
        {
            //die
        }

        public void SeeWiz(Mob mob)
        {
            //if(wiz is in attack range)
            //change to attack
        }

        public void WizOutOfSight(Mob mob)
        {
            //change to patrol
        }
    }
}
