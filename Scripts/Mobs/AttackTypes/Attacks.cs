using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttackTypes
{
	public class Attacks : Node2D
	{
		protected Timer attackLength;
		protected Timer attackCooldownTime;

		protected Mob mob;
		protected Node2D target;

		protected bool canAttack = true;

		public override void _Ready()
		{
			mob = (Mob)GetParent();
			target = (Wiz)GetParent().GetParent().GetNode("Wiz");
			attackLength = (Timer)GetNode("attackLength");
			attackCooldownTime = (Timer)GetNode("attackCooldownTime");
		}

		public virtual void Attack()
		{
			GD.Print(attackLength.TimeLeft);
			if(canAttack)
				attackLength.Start();
		}

		private void _on_attackLength_timeout()
		{
			attackCooldownTime.Start();
		}

		private void _on_attackCooldownTime_timeout()
		{
			canAttack = true;
		}
	}
	
}



