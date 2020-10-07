using Godot;
using System;

public class MapSpawner : Node2D
{
	[Export]
	PackedScene type1Room;
	[Export]
	PackedScene type2Room;
	[Export]
	PackedScene type3Room;
	[Export]
	PackedScene type0Room;

	TileMap outerWall;
	const short mapHeight = 5, mapWidth = 5;

	int[,] map = new int[mapHeight, mapWidth];

	public override void _Ready()
	{
		outerWall = (TileMap)GetNode("OuterWall");
		
		SpawnOuterWall();
	}

	private void GenerateRandomSolutionPath()
	{

	}

	private void AddRoomBasedOnType(int type,int x, int y)
	{
		switch(type)
		{
			case 0:
				break;
				AddInstanceOfRoom(type0Room, x, y);
			case 1:
				AddInstanceOfRoom(type1Room, x, y);
				break;
			case 2:
				AddInstanceOfRoom(type2Room, x, y);
				break;
			case 3:
				AddInstanceOfRoom(type3Room, x, y);
				break;
		}
	}

	private void AddInstanceOfRoom(PackedScene roomType,int x, int y)
	{
		Room newRoom = (Room)roomType.Instance();
		newRoom.GlobalPosition = new Vector2(x * TileSpawner.TileSize * Room.Rows, y * TileSpawner.TileSize * Room.Columns);
		AddChild(newRoom);
	}

	private void SpawnOuterWall()
	{
		int amountOfVerticalTiles = Room.Rows * mapHeight;
		int amountOfHorizontalTiles = Room.Columns * mapWidth;
		for (int i = -1; i <= amountOfVerticalTiles; i++)
		{
			for (int j = -1; j <= amountOfHorizontalTiles; j++)
			{
				if (i == -1 || i == amountOfVerticalTiles)
					outerWall.SetCell(i, j, 2);

				if (j == -1 || j == amountOfHorizontalTiles)
					outerWall.SetCell(i, j, 2);

			}
		}
	}

}
