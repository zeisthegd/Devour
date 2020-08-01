using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobStateMachine
{
    public interface IMobState
    {
        void PlayAnimation(Mob mob);
        void AutoPilot(Mob mob);
        void SeeWiz(Mob mob);
        void WizOutOfSight(Mob mob);
        void RunOutOfHealth(Mob mob);
    }
}
