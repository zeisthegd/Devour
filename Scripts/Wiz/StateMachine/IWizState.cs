using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizStateMachine
{
    public interface IWizState
    {
        void HandleInput(Wiz wiz);

        void PlayAnimation(Wiz wiz);
        void PressUp(Wiz wiz);
        void PressDown(Wiz wiz);
        void PressLeft(Wiz wiz);
        void PressRight(Wiz wiz);
        void PressAttack(Wiz wiz);
        void PressSpecial(Wiz wiz);
    }
}
