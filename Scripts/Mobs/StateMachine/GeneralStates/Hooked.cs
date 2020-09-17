using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobStateMachine
{
    class Hooked : MobState
    {
        public Hooked(StateMachine newStateMachine):base(newStateMachine)
        {
        }
        public override void AutoPilot()
        {
            mob.HookToWiz();
        }
        public override void PlayAnimation()
        {
           
        }
    }
}
