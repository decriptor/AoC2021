using System.Collections.Generic;

using NUnit.Framework;

using Shouldly;

namespace AdventOfCode2021.Tests
{
	public class Day6Tests
	{
		readonly List<int> testData = new () {
			3,4,3,1,2
		};

		[Test]
		public void Part1 ()
		{
			var result18Days = Day6.Part1 (testData, 18);
			result18Days.ShouldBe (26);

			var result80Days = Day6.Part1 (testData, 80);
			result80Days.ShouldBe (5934);

			var result80DaysReal = Day6.Part1 (Day6Data.Inputs, 80);
			result80DaysReal.ShouldBe (353274);
		}

		[Test]
		public void Part2 ()
		{
			var result80Days = Day6.Part1 (testData, 256);
			result80Days.ShouldBe (26984457539);

			//var result80DaysReal = Day6.Part1 (Day6Data.Inputs, 256);
			//result80DaysReal.ShouldBe (26984457539);

		}
	}
}