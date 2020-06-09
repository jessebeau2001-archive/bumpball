using System;
using GXPEngine;
using System.Drawing;

namespace GXPEngine
{
	class Brick : EasyDraw
	{

		int hitpoints;
		EasyDraw textContainer;
		public Brick (float x, float y, float width, float height)
			: this (new Vec2(x, y), new Vec2(width, height)) { }

		public Brick(Vec2 pos, Vec2 size) : base((int) size.x, (int) size.y)
		{
			x = pos.x;
			y = pos.y;
			ShapeAlign(CenterMode.Min, CenterMode.Min);
			Rect(0, 0, width, height);

			textContainer = new EasyDraw(width, height, false);
			textContainer.TextAlign(CenterMode.Center, CenterMode.Center);
			AddChild(textContainer);
			hitpoints = Utils.Random(10, 30);
		}

		void Update()
		{
			UpdateText(hitpoints.ToString());
		}

		void UpdateText(string text)
		{
			textContainer.Clear(Color.Transparent);
			textContainer.Fill(0, 0, 0);
			textContainer.Text(text, width / 2, height / 2);
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
	}
}
