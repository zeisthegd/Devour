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
		protected Timer windUpTime;

		protected Mob mob;
		protected Node2D target;

		protected bool canAttack = false;
		protected bool isWindingUp = false;

		public override void _Ready()
		{
			mob = (Mob)GetParent();
			target = (Wiz)GetParent().GetParent().GetNode("Wiz");
			attackLength = (Timer)GetNode("attackLength");
			attackCooldownTime = (Timer)GetNode("attackCooldownTime");
			GD.Print(attackCooldownTime.WaitTime);
			windUpTime = (Timer)GetNode("windUpTime");
		}

		public virtual void Attack()
		{
			if(canAttack)
			{
				attackLength.Start();			
			}				
		}
		public virtual void WindUp()
		{
			if(isWindingUp == false && canAttack == false)
			{
				isWindingUp = true;
				windUpTime.Start();
			}
		}
		private void _on_attackLength_timeout()
		{
			attackCooldownTime.Start();			
		}

		private void _on_attackCooldownTime_timeout()
		{
			WindUp();
		}
		private void _on_windUpTime_timeout()
		{
			isWindingUp = false;
			canAttack = true;
			Attack();
		}

	}

}








