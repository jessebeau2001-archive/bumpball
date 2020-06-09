using System;
using System.Drawing;
using GXPEngine;

public class MyGame : Game
{
	Level level;
	public MyGame() : base(1920, 1080, false, true)
	{
		level = new Level();
		AddChild(level);

		UnitTest test = new UnitTest();
		AddChild(test);
	}

	static void Main()
	{
		new MyGame().Start();
	}
}