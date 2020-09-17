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
        void PlayAnimation();
        void AutoPilot();
        void SeeWiz();
        void WizOutOfSight();
        void GetHooked();
        void RunOutOfHealth();
    }
}
