using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

public class RoomType1 : RoomType
{
	char[,] template1 = new char[,]
	{
		{ '0','0', '0', '0', '0', '0', '0', '0', '0', '0'},
		{ '1','1','0','0', '0', '0', '0', '0', '0', '0' },
		{ '0','0','0','0', '0', '0', '0', '0', '0', '0' },
		{ '0','1','0','0', '0', '0', '0', '0', '0', '0' },
		{ '1','0','0','0', '0', '0', '0', '0', '0', '0' },
		{ '1','1','0','0', '0', '0', '0', '0', '0', '0' },
		{ '1','1','0','0', '0', '0', '0', '0', '0', '0' },
		{ '1','1','1','1', '1', '1', '1', '1', '1', '1' },
	};
	public RoomType1()
	{
		templates.Add(template1);

		ChooseRandomRoomTemplate();
	}
	protected override void ChooseRandomRoomTemplate()
	{
		int randomTemplate = (int)GD.RandRange(0, templates.Count);	
	}
}
