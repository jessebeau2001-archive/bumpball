using System;
using GXPEngine.Core;
using System.Collections.Generic;
using System.Drawing;

namespace GXPEngine
{
	class Level : Pivot
	{
		List<Projectile> ballList = new List<Projectile>();
		List<Brick> bricks = new List<Brick>();
		AdvancedLine ray;

		Brick angled = new Brick(1000, 900, 100, 100);


		//MovingBox box = new MovingBox(new Vec2(0, 0), new Vec2(200, 200));
		
		Vec2 barrel;
		public Level()
		{
			barrel = new Vec2(game.width/ 2, game.height - 20); //define the startingpoint/barrel of where all the bullets come from

			ray = new AdvancedLine(barrel, new Vec2(0, 0), 400); //Used to cast a line with a set length from X to X
			AddChild(ray);

			for (int i = 0; i < 8; i++) //spawns all rows of bricks
				PopBricks(100, game.width - 100, 100 + (100 * i), 90);

			angled.rotation = 45;
			//AddChild(angled);
		}

		void Update()
		{
			Vec2 MouseVec = new Vec2(Input.mouseX, Input.mouseY);
			ray.UpdateRay(MouseVec);

			if (Input.GetMouseButtonDown(0))
			{
				ballList.Add(new Projectile(20, barrel, 20));
				AddChild(ballList[ballList.Count - 1]);
				Console.WriteLine(ballList.Count);
			}
		}

		void PopBricks(float startX, float endX, float y, float height)
		{
			bricks.Add(new Brick(startX, y, Utils.Random(50, 200), height));
			AddChild(bricks[bricks.Count - 1]);

			while (bricks[bricks.Count - 1].x + bricks[bricks.Count - 1].width < endX)
			{
				Brick lastBrick = bricks[bricks.Count - 1];
				if (lastBrick.x + lastBrick.width + 10 + 200 >= endX)
				{
					bricks.Add(new Brick(lastBrick.x + lastBrick.width + 10, y, endX - (lastBrick.x + lastBrick.width + 10), height));
					AddChild(bricks[bricks.Count - 1]);
					Console.WriteLine("Put down LAST brick");
					return;
				}
				if (Utils.Random(1, 10) == 8)
				{
				} else {
					bricks.Add(new Brick(lastBrick.x + lastBrick.width + 10, y, Utils.Random(50, 200), height));
					AddChild(bricks[bricks.Count - 1]);
					Console.WriteLine("Put down brick");
				}
			}
		}
	}
}
