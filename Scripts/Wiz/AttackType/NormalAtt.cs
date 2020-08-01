using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace Devour
{
    public class NormalAtt : FormAttacksStrategy
    {
        public override void Attack(Wiz wiz)
        {
            base.Attack(wiz);
            wiz.WizStateMachine.IsHooking = true;
            wiz.WizStateMachine.ChangeToHook();
        }

        public override void Special(Wiz wiz)
        {
            base.Special(wiz);
            wiz.WizStateMachine.ChangeToTransform();
        }
    }
}
