using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace Devour
{
	public class Kwissi: WizForms
	{
		public Kwissi(Wiz newWiz)
		{
			nameOfMob = "Kisi";
			AttachWiz(newWiz);
			formAttackType = new KwissiAtt();
		}

	}
}
