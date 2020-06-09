using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
	class UnitTest : Pivot
	{
		public UnitTest()
		{
			Console.WriteLine("all UnitTests");

			Vec2 point1 = new Vec2(70, 120);
			Vec2 point2 = new Vec2(20, 50);

			Vec2 roundNumber = new Vec2(3, 4);

			Console.Write("addition: ");
			Console.WriteLine(point1 + point2 == new Vec2(90, 170));

			Console.Write("removition: ");
			Console.WriteLine(point1 - point2 == new Vec2(50, 70));

			Console.Write("Scalar multiplication left: ");
			Console.WriteLine(point1 * 2 == new Vec2(140, 240));

			Console.Write("Scalar multiplication right: ");
			Console.WriteLine(2 * point1 == new Vec2(140, 240));

			Console.Write("division: ");
			Console.WriteLine(point1 / 2 == new Vec2(35, 60));

			Console.Write("Greater than: ");
			Console.WriteLine(point1 > point2 == true);

			Console.Write("Smaller than: ");
			Console.WriteLine(point1 < point2 == false);

			Console.Write("== to: ");
			Console.WriteLine(point1 == new Vec2(70, 120) == true);

			Console.Write("!= to: ");
			Console.WriteLine(point1 != new Vec2(70, 120) == false);

			Console.Write("Length(): ");
			Console.WriteLine(roundNumber.Length() == 5);

			Console.Write("Length(): ");
			Console.WriteLine(roundNumber.Length() == 5);

			Console.Write("Nomalized(): ");
			Console.WriteLine(roundNumber.Normalized() == new Vec2(0.6f, 0.8f));

			roundNumber.Normalize();
			Console.Write("Nomalize(): ");
			Console.WriteLine(roundNumber == new Vec2(0.6f, 0.8f));
		}
	}
}
