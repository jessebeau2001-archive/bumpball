using System;
using GXPEngine;
using System.Drawing;

namespace GXPEngine
{
	class Triangle : EasyDraw
	{

		int hitpoints;
		EasyDraw textContainer;
		Vec2 tilt;
		Vec2 top;
		Vec2 side;

		public Triangle(float x, float y, float width, float height)
			: this(new Vec2(x, y), new Vec2(width, height)) { }

		public Triangle(Vec2 pos, Vec2 size) : base((int) size.x, (int) size.y)
		{
			x = pos.x;
			y = pos.y;
			ShapeAlign(CenterMode.Min, CenterMode.Min);
			Triangle(0, 0, size.x, 0, size.x, size.y);

			textContainer = new EasyDraw(width, height, false);
			textContainer.TextAlign(CenterMode.Center, CenterMode.Center);
			AddChild(textContainer);
			hitpoints = Utils.Random(10, 30);

			top = new Vec2(0, size.x);
			side = new Vec2(size.y, 0);
			tilt = size;
		}

		void Update()
		{
			UpdateText(hitpoints.ToString());
		}

		void UpdateText(string text)
		{
			textContainer.Clear(Color.Transparent);
			textContainer.Fill(0, 0, 0);
			textContainer.Text(text, width / 2 + width / 4, height / 4);
		}

		public void GetHit()
		{
			hitpoints--;
			if (hitpoints <= 0)
				LateDestroy();
		}

		public Vec2 pos
		{
			get { return new Vec2(x, y); }
		}

		public Vec2 size
		{
			get { return new Vec2(width, height); }
		}

		public Vec2 normal
		{
			get { return tilt.Normal(); }
		}
	}
}
