using Godot;
using System;

public class TransformMobIcon : Node2D
{
	AnimationPlayer animationPlayer;
	Sprite mobIcon;
	Wiz wiz;
	string mobName;

	public override void _Ready()
	{
		mobName = "0";
		wiz = (Wiz)GetParent();
		animationPlayer = (AnimationPlayer)GetNode("animationPlayer");
		mobIcon = (Sprite)GetNode("icon");
		animationPlayer.Play("noInfo");
	}

	public override void _Process(float delta)
	{
		mobIcon.Texture = (Texture)ResourceLoader.Load("res://Art/Enemy/Kisi/icon.png");
		DisplayIcon();
	}

	private void DisplayIcon()
	{
		if (mobName != "0")
			animationPlayer.Play("haveInfo");
		else
			animationPlayer.Play("noInfo");
	}

	public void SetMobName(string newName)
	{
		this.mobName = newName;
	}

	public string MobName
	{
		get { return mobName; }
	}
}
