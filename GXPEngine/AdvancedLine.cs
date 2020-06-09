using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace GXPEngine
{
	class AdvancedLine : EasyDraw
	{
		private Vec2 _start;
		private Vec2 _end;
		private float _length;
		public AdvancedLine(Vec2 start, Vec2 end, float length) : base(1920, 1080)
		{
			_start = start;
			_end = end;
			_length = length;
		}

		public void UpdateRay(Vec2 newEnd)
		{
			_end = newEnd;

			Vec2 ray = _end - _start;
			ray.Normalize();
			ray *= _length;
			Clear(Color.Transparent);
			Line(_start.x, _start.y, _start.x + ray.x, _start.y + ray.y);
		}
	}
}
