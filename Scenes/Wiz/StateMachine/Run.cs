using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizStateMachine
{
    class Run : WizState
    {
        Vector2 tempVec;
        int runSpeed = 100;
        public Run(StateMachine newStateMachine) : base(newStateMachine)
        {
        }
        public override void HandleInput()
        {
            wiz.Velocity = new Vector2();

            PressUp();
            PressDown();
            PressRight();
            PressLeft();
            PlayAnimation();
            PressAttack();
            SetWizVelocity();
            VelocityEqualsZero();

        }

        public override void PressAttack()
        {
            if (Input.IsActionJustPressed("attack"))
            {
                if (wiz.CanUseHook)
                    wiz.FormAlgorithm.DoAttack();
            }
        }

        public override void PressSpecial()
        {

        }

        #region Run Algorhithm
        public override void PressDown()
        {
            if (Input.IsActionPressed("ui_down"))
                RunDown();
        }

        public override void PressLeft()
        {
            if (Input.IsActionPressed("ui_left"))
                RunLeft();
        }

        public override void PressRight()
        {
            if (Input.IsActionPressed("ui_right"))
                RunRight();
        }

        public override void PressUp()
        {
            if (Input.IsActionPressed("ui_up"))
                RunUp();
        }

        private void SetWizVelocity()
        {
            if (!stateMachine.IsAttacking)
                wiz.Velocity = wiz.Velocity.Normalized() * runSpeed;
        }

        private void RunLeft()
        {
            tempVec = wiz.Velocity;
            tempVec.x -= 1;
            wiz.Velocity = tempVec;
        }
        private void RunRight()
        {
            tempVec = wiz.Velocity;
            tempVec.x += 1;
            wiz.Velocity = tempVec;
        }
        private void RunUp()
        {
            tempVec = wiz.Velocity;
            tempVec.y -= 1;
            wiz.Velocity = tempVec;
        }
        private void RunDown()
        {
            tempVec = wiz.Velocity;
            tempVec.y += 1;
            wiz.Velocity = tempVec;
        }
        #endregion

        public override void PlayAnimation()
        {
            stateMachine.AnimationControl.ChangeAnimation(wiz.AnimationPlayer, "run");
        }

        private void VelocityEqualsZero()
        {
            if (wiz.Velocity == Vector2.Zero)
                ChangeToIdle();
        }

        private void AttackPressed()
        {
            runSpeed = 0;
            wiz.AttackTimer.Start();
            ChangeToAttack();
        }

        private void HookPressed()
        {
            stateMachine.IsHooking = true;
            ChangeToHook();
        }
    }
}
