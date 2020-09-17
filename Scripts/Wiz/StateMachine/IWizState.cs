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
        void HandleInput();

        void PlayAnimation();
        void PressUp();
        void PressDown();
        void PressLeft();
        void PressRight();
        void PressAttack();
        void PressSpecial();
    }
}
