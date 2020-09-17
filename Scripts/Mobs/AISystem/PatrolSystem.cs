using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;
using Utility;

namespace AISystem
{
	public class PatrolSystem : Node
	{
		Timer idleDuration;
		bool idleTimerStarted = false;
		[Export]
		float maxIdleTime = 1.5F;

		Random rand = new Random();
		int random;

		int maxDistanceToMove = 2;
		string direction;
		Vector2 tempMobVelocity;

		Vector2 mobGlobalPos;
		int mobGlobalPosX;
		int mobGlobalPosY;

		string actionToDo;
		Vector2 waypoint;
		public override void _Ready()
		{
			idleDuration = (Timer)GetNode("idleDuration");
			actionToDo = "Patrol";
		}

		public void DoPatrol(Mob mob)
		{
			if (actionToDo == "Idle")
				StayIdle(mob);
			else if (actionToDo == "Patrol")
				KeepPatrolling(mob);
			mob.Velocity = mob.Velocity.Normalized();
		}

		private void KeepPatrolling(Mob mob)
		{
			mobGlobalPosX = Mathf.FloorToInt(mob.GlobalPosition.x);
			mobGlobalPosY = Mathf.FloorToInt(mob.GlobalPosition.y);
			mobGlobalPos = new Vector2(mobGlobalPosX, mobGlobalPosY);

			if (mob.Velocity == Vector2.Zero)
				SetWayPoint(mob);

			if (mobGlobalPos == waypoint)
			{
				actionToDo = "Idle";
				mob.Velocity = Vector2.Zero;
			}
			else
				mob.Velocity = waypoint - mob.GlobalPosition;
		}
		private void StayIdle(Mob mob)
		{
			if (idleTimerStarted == false)
			{
				float randomIdleTime = RandomFloatNumber();
				idleTimerStarted = true;
				idleDuration.WaitTime = randomIdleTime;
				idleDuration.Start();
				mob.Velocity = Vector2.Zero;
			}
		}

		private float RandomFloatNumber()
		{
			var randGenerator = new RandomNumberGenerator();
			randGenerator.Randomize();
			float randFloat = randGenerator.RandfRange(1, maxIdleTime);
			return randFloat;
		}

		private string RandomAction()
		{
			int randomAction = rand.Next(0, 2);
			return randomAction == 0 ? "Idle" : "Patrol";
		}


		private void SetWayPoint(Mob mob)
		{
			string randomDirection = RandomDirection();
			if (randomDirection == "Left")
				waypoint = SetDestinationLeft(mob);
			else if (randomDirection == "Right")
				waypoint = SetDestinationRight(mob);
			else if (randomDirection == "Up")
				waypoint = SetDestinationUp(mob);
			else if (randomDirection == "Down")
				waypoint = SetDestinationDown(mob);
		}

		public string RandomDirection()
		{
			Random rand = new Random();
			int randomDir = rand.Next(1, 5);
			if (randomDir == 1)
				direction = "Down";
			else if (randomDir == 2)
				direction = "Right";
			else if (randomDir == 3)
				direction = "Up";
			else if (randomDir == 4)
				direction = "Left";
			return direction;
		}

		public int RandomPatrolDistance()
		{
			Random rand = new Random();
			int randomDist = rand.Next(0, maxDistanceToMove);
			return randomDist;
		}

		private Vector2 SetDestinationLeft(Mob mob)
		{
			Vector2 dest;
			dest = new Vector2(Mathf.FloorToInt(mob.GlobalPosition.x - mob.SpriteSize * RandomPatrolDistance()),
				Mathf.FloorToInt(mob.GlobalPosition.y));
				return dest;
		}
		private Vector2 SetDestinationRight(Mob mob)
		{
			Vector2 dest;
			dest = new Vector2(Mathf.FloorToInt(mob.GlobalPosition.x + mob.SpriteSize * RandomPatrolDistance()),
				Mathf.FloorToInt(mob.GlobalPosition.y));
				return dest;
		}
		private Vector2 SetDestinationUp(Mob mob)
		{
			Vector2 dest;
			dest = new Vector2(Mathf.FloorToInt(mob.GlobalPosition.x),
				Mathf.FloorToInt(mob.GlobalPosition.y - mob.SpriteSize * RandomPatrolDistance()));
				return dest;
		}
		private Vector2 SetDestinationDown(Mob mob)
		{
			Vector2 dest;
			dest = new Vector2(Mathf.FloorToInt(mob.GlobalPosition.x),
				Mathf.FloorToInt(mob.GlobalPosition.y + mob.SpriteSize * RandomPatrolDistance()));
				return dest;
		}

		private void _on_idleDuration_timeout()
		{
			idleTimerStarted = false;
			actionToDo = "Patrol";
		}

	}
}



