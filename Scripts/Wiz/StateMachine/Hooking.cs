using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizHook;

namespace WizStateMachine
{
	class Hooking : IWizState
	{
		StateMachine stateMachine;
		[Export]
		PackedScene hookScene = (PackedScene)GD.Load("res://Scenes/Wiz/Hook/Hook.tscn");

		public Hooking(StateMachine newStateMachine)
		{

			this.stateMachine = newStateMachine;
		}



		public void HandleInput(Wiz wiz)
		{

			ShootTheHook(wiz);
			//revoke
			ChangeToIdle(wiz);
		}

		private void ShootTheHook(Wiz wiz)
		{
			if (wiz.Hook == null)
			{
				
				Vector2 localMousePosition = wiz.GetLocalMousePosition();
				Vector2 hookDiretion = DirectionToMouse(wiz, wiz.GetGlobalMousePosition());
				//spawn the hook
				
				Hook newHook = (Hook)hookScene.Instance();
				newHook.SetDirectionAndRotation(hookDiretion, localMousePosition.Angle());
				//newHook.Velocity = newHook.Direction.Normalized() * 475;

				wiz.Velocity = Vector2.Zero;

				wiz.AddChild(newHook);
				wiz.Hook = newHook;	
			}
		}

		private void ChangeToIdle(Wiz wiz)
		{
			if (stateMachine.IsHooking == false)
			{
				stateMachine.SetWizState(stateMachine.GetIdleState());
			}
		}

		private Vector2 DirectionToMouse(Wiz wiz, Vector2 mousePosition)
		{
			return (mousePosition - wiz.Position);
		}

		public void PlayAnimation(Wiz wiz)
		{
			throw new NotImplementedException();
		}

		public void PressAttack(Wiz wiz)
		{
			throw new NotImplementedException();
		}

		public void PressDown(Wiz wiz)
		{
			throw new NotImplementedException();
		}

		public void PressLeft(Wiz wiz)
		{
			throw new NotImplementedException();
		}

		public void PressRight(Wiz wiz)
		{
			throw new NotImplementedException();
		}

		public void PressUp(Wiz wiz)
		{
			throw new NotImplementedException();
		}
		public void PressSpecial(Wiz wiz)
		{
			
		}
	}
}
