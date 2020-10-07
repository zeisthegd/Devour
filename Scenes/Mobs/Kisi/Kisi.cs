using Godot;
using System;
using AttackTypes;
using MobStateMachine;

public class Kisi : Mob
{ 
	public override void _Ready()
	{
		base._Ready();
		this.mobName = "Kisi";
		this.moveSpeed = 1;
		this.hookedSpeed = 8;
		this.SpriteSize = 24;
		attackStrategy = (Attacks)GetNode("Gore");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		base._Process(delta);		
	}
	public override void ChangeFormManagerNextForm()
	{
		base.ChangeFormManagerNextForm();
		wiz.FormManager.ChangeNextForm(Devour.FormManager.Form.Kwissi);
	}
}
