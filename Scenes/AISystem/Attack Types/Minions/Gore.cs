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
		short speedMultiplier = 3;

		Vector2 mobGlobalPos;
		int mobGlobalPosX;
		int mobGlobalPosY;

		public override void Attack()
		{
			base.Attack();
			mobGlobalPos = CalculateMobGlobalPos();	
			if (!isWindingUp && canAttack)
			{
				Vector2 waypoint = SetChargeWaypoint();
				mob.Velocity = (waypoint - mob.GlobalPosition).Normalized() * speedMultiplier;
				canAttack = false;
			}
			if (attackLength.TimeLeft <= 0)
			{
				mob.Velocity = Vector2.Zero;				
			}			
		}
		public override void WindUp()
		{
			base.WindUp();
			mob.Velocity = Vector2.Zero;
			mob.RotationDegrees += 90;
		}

		public Vector2 CalculateMobGlobalPos()
		{
			mobGlobalPosX = Mathf.FloorToInt(mob.GlobalPosition.x);
			mobGlobalPosY = Mathf.FloorToInt(mob.GlobalPosition.y);
			return new Vector2(mobGlobalPosX, mobGlobalPosY);
		}

		private Vector2 SetChargeWaypoint()
		{
			Vector2 dest;
			dest = new Vector2(Mathf.FloorToInt(target.GlobalPosition.x),
				Mathf.FloorToInt(target.GlobalPosition.y));
			return dest;
		}
	}
}
