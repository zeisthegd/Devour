using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace WizHook
{
	public class Hook : Area2D
	{
		Vector2 velocity = new Vector2();
		Vector2 direction = new Vector2();

		Timer hookLength;
		Area2D revokeArea;

		bool isRevoking = false;

		Wiz wiz;

		[Export]
		float speed = 8;


		public override void _Ready()
		{
			wiz = (Wiz)GetParent();
			this.Position = Vector2.Zero;
			hookLength = (Timer)GetNode("hookLength");
			hookLength.Start();

			velocity = direction.Normalized() * speed * 1.0F;

		}
		public override void _Process(float delta)
		{
			if(isRevoking)
				Revoke();
		}
		public override void _PhysicsProcess(float delta)
		{
			Position += Velocity;
		}
		public void SetDirectionAndRotation(Vector2 newDirection, float pointToLookAt)
		{
			direction = newDirection;
			this.Rotation = 0;
			this.Rotation += pointToLookAt;
		}


		private void _on_hookLength_timeout()
		{
			isRevoking = true;
			wiz.WizStateMachine.IsHooking = false;
		}

		private void ChangeWizIsHookingBoolToFalse()
		{
			wiz.WizStateMachine.IsHooking = false;
		}

		private void _on_Hook_body_entered(KinematicBody2D body)
		{
			if (GroupCheck.IsInWiz(body))
			{
				if(isRevoking)
				{
					QueueFree();
					wiz.Hook = null;
				}
			}
			else if(GroupCheck.IsInStaticObjects(body))
			{
				isRevoking = true;
				ChangeWizIsHookingBoolToFalse();
			}

		}

		private void _on_Hook_area_entered(Area2D area)
		{
			if (GroupCheck.IsInHookable(area))
			{
				isRevoking = true;
				ChangeWizIsHookingBoolToFalse();
				//and change animation to grip
			}
		}

		private void Revoke()
		{
			Vector2 directionToWiz = (wiz.Position - this.GlobalPosition);
			directionToWiz += new Vector2(0, 5);
			SetDirectionAndRotation(directionToWiz, wiz.Position.Angle());
			velocity = direction.Normalized() * speed * 1.0F;		
		}

		

		#region Properties

		public Vector2 Velocity
		{
			get { return velocity; }
			set { velocity = value; }
		}

		public Vector2 Direction
		{
			get { return direction; }
			set { direction = value; }
		}
		public Timer HookLength
		{
			get { return hookLength; }
		}
		#endregion


	}
}








