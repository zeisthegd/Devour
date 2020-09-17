using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobStateMachine
{
	public class StateMachine
	{
		MobState patrol;
		MobState attack;
		MobState chase;
		MobState die;
		MobState hooked;

		MobState mobState;

		Mob mob;

		Animation.AnimationControl animationControl = new Animation.AnimationControl();
		bool isBeingHooked = false;
		int runSpeed = 100;
		float distanceToAttack = 100;

		

		public StateMachine(Mob newMob)
		{
			this.mob = newMob;

			patrol = new Patrol(this);
			attack = new Attack(this);
			chase = new Chase(this);
			hooked = new Hooked(this);
			mobState = patrol;
		}

		public void Action()
		{
			animationControl.ChangeMobAnimationDirection(this.mob);
			mobState.AutoPilot();
		}

		public void SetMobState(MobState newMobState)
		{
			this.mobState = newMobState;
		}

		public MobState HookedState {get => hooked; }
		public MobState PatrolState { get => patrol; }
		public MobState ChaseState { get => chase; }
		public MobState AttackState { get => attack; }

		public bool IsBeingHooked
		{
			get { return isBeingHooked; }
			set { isBeingHooked = value; }
		}

        public Mob Mob { get => mob;}
		public Animation.AnimationControl AnimationControl
		{
			get { return animationControl; }
		}
	}
}
