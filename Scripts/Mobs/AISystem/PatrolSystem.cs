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
		Position2D leftBoundary;
		Position2D rightBoundary;
		Position2D upperBoundary;
		Position2D lowerBoundary;

		Timer idleDuration;
		bool idleTimerStarted = false;
		[Export]
		byte maxIdleTime = 2;

		Random rand = new Random();
		int random;
		float leftBound, rightBound, upperBound, lowerBound;

		int maxDistanceToMove = 2;
		string direction;
		Vector2 tempMobVelocity;

		Vector2 mobGlobalPos;
		int mobGlobalPosX;
		int mobGlobalPosY;

		string actionToDo;
		Vector2 waypoint;
		float leftDest, rightDest, upperDest, lowerDest;


		public override void _Ready()
		{
			//leftBoundary = (Position2D)GetParent().GetParent().GetNode("leftBound");//get mob -> get scene -> get position
			//rightBoundary = (Position2D)GetParent().GetParent().GetNode("rightBound");
			//upperBoundary = (Position2D)GetParent().GetParent().GetNode("upperBound");
			//lowerBoundary = (Position2D)GetParent().GetParent().GetNode("lowerBound");

			idleDuration = (Timer)GetNode("idleDuration");
			actionToDo = "Patrol";
			base._Ready();
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
			mobGlobalPosX = Calculations.RoundOff((int)mob.GlobalPosition.x);
			mobGlobalPosY = Calculations.RoundOff((int)mob.GlobalPosition.y);
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
			dest = new Vector2(Calculations.RoundOff((int)mob.GlobalPosition.x - mob.SpriteSize * RandomPatrolDistance()),
				Calculations.RoundOff((int)(mob.GlobalPosition.y)));
			//if (dest.x < leftBoundary.GlobalPosition.x)
			//	return SetDestinationLeft(mob);
			//else
				return dest;
		}
		private Vector2 SetDestinationRight(Mob mob)
		{
			Vector2 dest;
			dest = new Vector2(Calculations.RoundOff((int)mob.GlobalPosition.x + mob.SpriteSize * RandomPatrolDistance()),
				Calculations.RoundOff((int)(mob.GlobalPosition.y)));
			rightDest = dest.x;
			//if (dest.x > rightBoundary.GlobalPosition.x)
			//	return SetDestinationRight(mob);
			//else
				return dest;
		}
		private Vector2 SetDestinationUp(Mob mob)
		{
			Vector2 dest;
			dest = new Vector2(Calculations.RoundOff((int)(mob.GlobalPosition.x)),
				Calculations.RoundOff((int)mob.GlobalPosition.y - mob.SpriteSize * RandomPatrolDistance()));
			//if (dest.y < rightBoundary.GlobalPosition.y)
			//	return SetDestinationUp(mob);
			//else
				return dest;
		}
		private Vector2 SetDestinationDown(Mob mob)
		{
			Vector2 dest;
			dest = new Vector2(Calculations.RoundOff((int)(mob.GlobalPosition.x)),
				Calculations.RoundOff((int)mob.GlobalPosition.y + mob.SpriteSize * RandomPatrolDistance()));
			//if (dest.y > rightBoundary.GlobalPosition.y)
			//	return SetDestinationDown(mob);
			//else
				return dest;
		}


		public bool CheckLeftBoundary(Mob mob)
		{
			if (mob.GlobalPosition.x - mob.SpriteSize * RandomPatrolDistance() < leftBound)
				return false;
			else return true;
		}

		private void _on_idleDuration_timeout()
		{
			idleTimerStarted = false;
			actionToDo = "Patrol";
		}

	}
}



