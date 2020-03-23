using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobStateMachine
{
    class StateMachine
    {
        #region States
        MobState patrol;
        MobState attack;
        MobState die;
        #endregion

        #region Mob
        Mob mob;

        #endregion

        Animation.AnimationControl animationControl = new Animation.AnimationControl();
        bool isAttacking = false;
        int runSpeed = 100;

        public Animation.AnimationControl AnimationControl
        {
            get { return animationControl; }
        }

        public StateMachine()
        {
            patrol = new GeneralStates.Patrol();
            attack = new GeneralStates.Attack();
        }
    }
}
