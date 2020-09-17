using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobStateMachine
{
    class Chase : MobState
    {
        public Chase(StateMachine newStateMachine):base(newStateMachine)
        {
        }

        public override void AutoPilot()
        {
            base.AutoPilot();
        }

        public override void PlayAnimation()
        {
            
        }

        public override void RunOutOfHealth()
        {
            //die
        }

        public override void SeeWiz()
        {
            //if(wiz is in attack range)
            //change to attack
        }

        public override void WizOutOfSight()
        {
            //change to patrol
        }
    }
}
