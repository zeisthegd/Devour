using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace Devour
{
	public class WizForms : Node2D
	{
		protected Wiz wiz;

		protected string nameOfMob;
		protected AnimationPlayer animationPlayer;
		protected FormAttacksStrategy formAttackType;

		public override void _Ready()
		{
			this.wiz = (Wiz)GetParent();
			animationPlayer = (AnimationPlayer)GetNode("animationPlayer");
		}


		protected void AttachWiz(Wiz newWiz)
		{
			
			wiz = newWiz;
		}

		public void DoAttack()
		{
			formAttackType.Attack(wiz);
		}
		public void UseSpecial()
		{
			formAttackType.Special(wiz);
		}

		public AnimationPlayer AnimationPlayer
		{
			get { return animationPlayer; }
		}

		public FormAttacksStrategy AttacksStrategy
		{
			get { return formAttackType; }
		}
	}
}
