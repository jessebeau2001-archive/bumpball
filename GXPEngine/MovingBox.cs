using System.Drawing;

namespace GXPEngine
{
	class MovingBox : Brick
	{
		bool stuck;
		public MovingBox(Vec2 pos, Vec2 size, bool stuck = true) : base(pos, size)
		{
			this.stuck = stuck;
			Clear(Color.Transparent);
			Fill(245, 111, 66);

			Rect(0, 0, width, height);

			SetOrigin(width / 2, height / 2);
		}

		void Update()
		{
			if (Input.GetKey(Key.W))
				y -= 10;

			if (Input.GetKey(Key.S))
				y += 10;

			if (Input.GetKey(Key.A))
				x -= 10;

			if (Input.GetKey(Key.D))
				x += 10;

			if (Input.GetKey(Key.RIGHT))
				rotation += 2;
			if (Input.GetKey(Key.LEFT))
				rotation -= 2;
		}

		void OnCollision(GameObject other)
		{
			if (stuck) return;
			var colInfo = collider.GetCollisionInfo(other.collider);

			x += colInfo.penetrationDepth * colInfo.normal.x;
			y += colInfo.penetrationDepth * colInfo.normal.y;
		}
	}
}
