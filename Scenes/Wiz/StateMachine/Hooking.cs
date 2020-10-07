using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizHook;

namespace WizStateMachine
{
	class Hooking : WizState
	{
		[Export]
		PackedScene hookScene = (PackedScene)GD.Load("res://Scenes/Wiz/Hook/Hook.tscn");

		public Hooking(StateMachine newStateMachine) : base(newStateMachine)
		{
		}
		public override void HandleInput()
		{
			ShootTheHook();
			NotHooking();
		}

		private void ShootTheHook()
		{
			if (wiz.Hook == null)
			{			
				Vector2 localMousePosition = wiz.GetLocalMousePosition();
				Vector2 hookDiretion = DirectionToMouse(wiz.GetGlobalMousePosition());
				
				Hook newHook = (Hook)hookScene.Instance();
				newHook.SetDirectionAndRotation(hookDiretion, localMousePosition.Angle());

				wiz.Velocity = Vector2.Zero;

				wiz.AddChild(newHook);
				wiz.Hook = newHook;	
			}
		}

		private void NotHooking()
		{
			if (stateMachine.IsHooking == false)
			{
				ChangeToIdle();
			}
		}

		private Vector2 DirectionToMouse( Vector2 mousePosition)
		{
			return (mousePosition - wiz.Position);
		}

		public override void PlayAnimation()
		{
			throw new NotImplementedException();
		}
	}
}
