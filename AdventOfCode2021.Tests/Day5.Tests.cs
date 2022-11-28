using System.Collections.Generic;

using NUnit.Framework;

using Shouldly;

namespace AdventOfCode2021.Tests
{
	public class Day5Tests
	{
		readonly List<string> testData = new () {
			"0,9,5,9",
			"8,0,0,8",
			"9,4,3,4",
			"2,2,2,1",
			"7,0,7,4",
			"6,4,2,0",
			"0,9,2,9",
			"3,4,1,4",
			"0,0,8,8",
			"5,5,8,2"
		};

		[Test]
		public void Part1 ()
		{
			var overlaps = Day5.Part1 (10, testData);
			overlaps.ShouldBe (12);

			var overlapsReal = Day5.Part1 (1000, Day5Data.Lines);
			overlapsReal.ShouldBe (22088);
		}

		[Test]
		public void Part2 ()
		{
		}
	}
}