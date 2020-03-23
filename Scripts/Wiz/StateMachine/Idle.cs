using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace WizStateMachine
{
    class Idle : WizState
    {
        StateMachine stateMachine;

        public Idle(StateMachine newStateMachine)
        {
            stateMachine = newStateMachine;
        }
        public void HandleInput(Wiz wiz)
        {
            //GD.Print("idle");
            wiz.Velocity = new Vector2();

            PressDown(wiz);
            PressLeft(wiz);
            PressRight(wiz);
            PressUp(wiz);

            PlayAnimation(wiz);

            PressAttack(wiz);

        }

        public void PressAttack(Wiz wiz)
        {
            if (Input.IsActionJustPressed("ui_attack"))
                ChangeToAttack(wiz);
        }

        public void PressDown(Wiz wiz)
        {
            if (Input.IsActionPressed("ui_down"))
                ChangeToRun();

        }

        public void PressLeft(Wiz wiz)
        {
            if (Input.IsActionPressed("ui_left"))
                ChangeToRun();

        }

        public void PressRight(Wiz wiz)
        {
            if (Input.IsActionPressed("ui_right"))
                ChangeToRun();

        }

        public void PressUp(Wiz wiz)
        {
            if (Input.IsActionPressed("ui_up"))
                ChangeToRun();

        }

        public void PlayAnimation(Wiz wiz)
        {
            stateMachine.AnimationControl.ChangeAnimation(wiz.AnimationPlayer, "idle");
        }

        void ChangeToRun()
        {
            stateMachine.SetWizState(stateMachine.GetRunState());
        }
        private void ChangeToAttack(Wiz wiz)
        {
            wiz.AttackTimer.Start();
            stateMachine.SetWizState(stateMachine.GetAttackState());
        }

    }
}
