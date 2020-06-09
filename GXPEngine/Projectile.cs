using System;
using GXPEngine;
using GXPEngine.Core;

namespace GXPEngine
{
	class Projectile : EasyDraw
	{
		private Vec2 _position;
		private Vec2 _velocity;
		private Vec2 _force;

		private float _speed;
		private int _radius;

		public Projectile(int radius, Vec2 startPos, float speed) : base (radius * 2 + 1, radius * 2 + 1)//+1 because GXP makes the colBox 1px smaller o_O
		{
			_position = startPos;
			Console.WriteLine(_position);
			_speed = speed;
			_radius = radius;

			SetOrigin(radius, radius);
			Ellipse(_radius, _radius, 2 * _radius, 2 * _radius);

			x = _position.x;
			y = _position.y;
			Shoot();
		}

		void Update()
		{
			if(x < _radius || x > game.width - _radius)
				_velocity.Reflect(new Vec2(0, 100).Normal(), 1f);
			
			if (y < _radius)
				_velocity.Reflect(new Vec2(100, 0).Normal(), 1f);
			
			if (y > game.height + _radius)//+ radius so its out of the screen
				Destroy();

			//_velocity += _force; //Not used because balls are not accelerating
			//_force *= .98f;
			_position += _velocity * Time.deltaTime;
			//_velocity *= 0;
			
			x = _position.x;
			y = _position.y;
		}

		public void Shoot()
		{
			_velocity = new Vec2(Input.mouseX - _position.x, Input.mouseY - _position.y);
			_velocity.Normalize();
		}

		void OnCollision(GameObject other)
		{
			if (other is Projectile) return;

			var colInfo = collider.GetCollisionInfo(other.collider);

			if (other is Brick)
			{
					_velocity.Reflect(new Vec2(colInfo.normal), 1);
					(other as Brick).GetHit();
			}

			if (other is Triangle)
			{
				Triangle col = (other as Triangle);

				
				_velocity.Reflect(col.normal, 1);
			}
		}

		public Vec2 position
		{
			get { return _position; }
		}
	}
}
