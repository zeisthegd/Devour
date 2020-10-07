using Godot;
using System;

public class Room : Node2D
{
	const short rows = 8, columns = 10;
	RoomType type;
	TileSpawner tileSpawner;
   
	public override void _Ready()
	{
		type = (RoomType)GetNode("roomType");
	}

	public static short Rows => rows;
	public static short Columns => columns;
}
