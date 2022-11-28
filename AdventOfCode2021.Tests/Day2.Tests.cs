using System.Collections.Generic;

using NUnit.Framework;

using Shouldly;

namespace AdventOfCode2021.Tests
{
	public class Day2Tests
	{
		[Test]
		public void Part1 ()
		{
			var result = Day2.CalculateSubPostion (Day2Data.Directions);
			result.horizontalPosition.ShouldBe(1790);
			result.depth.ShouldBe(1222);
			Day2.GetFinalValue (result).ShouldBe (2187380);
		}

		[Test]
		public void Part2()
		{
			var result = Day2.CalculateSubPositionPart2 (Day2Data.Directions);
			result.horizontalPosition.ShouldBe (1790);
			result.depth.ShouldBe (1165563);
			Day2.GetFinalValue (result).ShouldBe (2086357770);
		}
	}
}