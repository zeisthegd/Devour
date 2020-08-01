using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralStates
{
    class Hooked : MobStateMachine.IMobState
    {
        MobStateMachine.StateMachine stateMachine;

        public Hooked(MobStateMachine.StateMachine newStateMachine)
        {
            stateMachine = newStateMachine;

        }
        public void AutoPilot(Mob mob)
        {
            if(stateMachine.IsHookingMob)
            {
                mob.HookToWiz();
            }
        }

        public void PlayAnimation(Mob mob)
        {
            throw new NotImplementedException();
        }

        public void RunOutOfHealth(Mob mob)
        {
            throw new NotImplementedException();
        }

        public void SeeWiz(Mob mob)
        {
            throw new NotImplementedException();
        }

        public void WizOutOfSight(Mob mob)
        {
            throw new NotImplementedException();
        }
    }
}
