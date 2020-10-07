using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace Devour
{
	public class NormalWiz : WizForms
	{
		public NormalWiz(Wiz newWiz)
		{
			AttachWiz(newWiz);
			formAttackType = new NormalAtt();
		}
		public override void _Ready()
		{
			base._Ready();
		}
	}
}
