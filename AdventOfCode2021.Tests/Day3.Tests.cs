using System.Collections.Generic;

using NUnit.Framework;

using Shouldly;

namespace AdventOfCode2021.Tests
{
	public class Day3Tests
	{
		List<string> testData = new () {
			"00100",
			"11110",
			"10110",
			"10111",
			"10101",
			"01111",
			"00111",
			"11100",
			"10000",
			"11001",
			"00010",
			"01010"
		};

		[Test]
		public void Part1 ()
		{
			var result = Day3.CalculateGammaEpsilon (Day3Data.Diagnostics);
			result.gammaRate.ShouldBe (2028);
			result.epsilonRate.ShouldBe (2067);
			var consumption = Day3.CalculateConsumptionRate (result);
			consumption.ShouldBe (4191876);
		}

		[Test]
		public void Part2 ()
		{
			var oxygenTest = Day3.CalculateOxygenGeneratorRating (testData);
			oxygenTest.ShouldBe (23);
			var co2Test = Day3.CalculateCO2ScrubberRating (testData);
			co2Test.ShouldBe (10);

			var oxygen = Day3.CalculateOxygenGeneratorRating (Day3Data.Diagnostics);
			oxygen.ShouldBe (1391);
			var co2 = Day3.CalculateCO2ScrubberRating (Day3Data.Diagnostics);
			co2.ShouldBe (2455);

			var lifeSupportRating = Day3.CalculateLifeSupportRate ((oxygen, co2));
			lifeSupportRating.ShouldBe (3414905);
		}
	}
}