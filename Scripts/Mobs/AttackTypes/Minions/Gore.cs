using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;
using Utility;

namespace AttackTypes
{
	class Gore : Attacks
	{

		short speedMultiplier = 2;

		Vector2 mobGlobalPos;
		int mobGlobalPosX;
		int mobGlobalPosY;

		public override void Attack()
		{
			base.Attack();
			mobGlobalPos = CalculateMobGlobalPos();	
			if (canAttack)
			{
				Vector2 waypoint = SetChargeWaypoint();
				mob.Velocity = (waypoint - mob.GlobalPosition).Normalized() * speedMultiplier;
				canAttack = false;
			}
			if (attackLength.TimeLeft <= 0)
				mob.Velocity = Vector2.Zero;

		}

		public Vector2 CalculateMobGlobalPos()
		{
			mobGlobalPosX = Calculations.RoundOff((int)mob.GlobalPosition.x);
			mobGlobalPosY = Calculations.RoundOff((int)mob.GlobalPosition.y);
			return new Vector2(mobGlobalPosX, mobGlobalPosY);
		}

		private Vector2 SetChargeWaypoint()
		{
			Vector2 dest;
			dest = new Vector2(Calculations.RoundOff((int)target.GlobalPosition.x),
				Calculations.RoundOff((int)target.GlobalPosition.y));
			//if (dest.x < leftBoundary.GlobalPosition.x)
			//	return SetDestinationLeft(mob);
			//else
			return dest;
		}
	}
}
