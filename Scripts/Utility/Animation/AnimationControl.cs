using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animation
{
    public class AnimationControl
    {
        private string animationDirection = "Down";

        public string AnimationDirection
        {
            get { return animationDirection; }
        }

        public void ChangeWizAnimationDirection()
        {
            if (Input.IsActionPressed("ui_down"))
                animationDirection = "Down";
            else if (Input.IsActionPressed("ui_up"))
                animationDirection = "Up";
            if (Input.IsActionPressed("ui_left"))
                animationDirection = "Left";
            else if (Input.IsActionPressed("ui_right"))
                animationDirection = "Right";
        }
        public void ChangeMobAnimationDirection(Mob mob)
        {
            if (mob.Velocity.y > 0 && Mathf.Abs(mob.Velocity.y) > Mathf.Abs(mob.Velocity.x))
                animationDirection = "Down";
            else if (mob.Velocity.y < 0 && Mathf.Abs(mob.Velocity.y) > Mathf.Abs(mob.Velocity.x))
                animationDirection = "Up";
            if (mob.Velocity.x < 0 && Mathf.Abs(mob.Velocity.x) > Mathf.Abs(mob.Velocity.y))
                animationDirection = "Left";
            else if (mob.Velocity.x > 0 && Mathf.Abs(mob.Velocity.x) > Mathf.Abs(mob.Velocity.y))
                animationDirection = "Right";
        }

        public void ChangeAnimation(AnimationPlayer objectAnimationPlayer, string animationType)
        {
            objectAnimationPlayer.Play(animationType + animationDirection);
        }

    }
}
