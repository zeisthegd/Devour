using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace Devour
{
	public class FormAttacksStrategy: Node2D
	{
		protected bool canAttack = true;

		public virtual void Attack(Wiz wiz) { }
		public virtual void Special(Wiz wiz) { }

		private void _on_attackDuation_timeout()
		{
			// Replace with function body.
		}


		private void _on_attackCooldowntime_timeout()
		{
			// Replace with function body.
		}
	}
	
}



