using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class RoomType: Node2D
{
	protected List<char[,]> templates = new List<char[,]>();
	protected char[,] chosenTemplate;
	public RoomType()
	{
		ChooseRandomRoomTemplate();  
	}

	protected virtual void ChooseRandomRoomTemplate()
	{

	}

}

