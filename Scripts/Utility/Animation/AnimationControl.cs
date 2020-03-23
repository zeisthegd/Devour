using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animation
{
    class AnimationControl
    {
        private string animationDirection;

        public AnimationControl()

            {
            animationDirection = "Down";
            }
        public string AnimationDirection
        {
            get { return animationDirection; }
        }
        public void ChangeAnimationDirection()
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

        public void ChangeAnimation(AnimationPlayer objectAnimationPlayer,string animationType)
        {
            objectAnimationPlayer.Play(animationType + animationDirection);
            GD.Print(animationType + animationDirection);
        }

    }
}
