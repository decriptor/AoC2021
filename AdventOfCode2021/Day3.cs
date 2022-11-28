using System;

namespace AdventOfCode2021
{
	public static class Day3
	{
		public static (int gammaRate, int epsilonRate) CalculateGammaEpsilon (List<string> diagnosticData)
		{
			string gammaRateString = "";
			string epsilonRateString = "";
			int diagnosticDataLength = diagnosticData.First ().Length;

			for (int i = 0; i < diagnosticDataLength; i++) {
				int oneCount = 0;
				int zeroCount = 0;
				for (int j = 0; j < diagnosticData.Count; j++) {
					if (diagnosticData[j][i] == '1')
						oneCount++;
					else
						zeroCount++;
				}

				gammaRateString += (oneCount > zeroCount) ? "1" : "0";
				epsilonRateString += (oneCount > zeroCount) ? "0" : "1";
			}
			//Console.WriteLine (gammaRateString);
			var gammaRate = Convert.ToInt32 (gammaRateString, 2);
			//Console.WriteLine (gammaRate);
			//Console.WriteLine (epsilonRateString);
			var epsilonRate = Convert.ToInt32 (epsilonRateString, 2);
			//Console.WriteLine (epsilonRate);

			return (gammaRate, epsilonRate);
		}

		public static int CalculateConsumptionRate ((int gammaRate, int epsilonRate) rates)
		{
			return rates.gammaRate * rates.epsilonRate;
		}

		public static int CalculateOxygenGeneratorRating (List<string> diagnosticData)
		{
			var diagnosticDataLength = diagnosticData.First ().Length;
			var reducedList = new List<string> (diagnosticData);
			for (int i = 0; i < diagnosticDataLength; i++) {
				var bit = FindMostCommonBit (reducedList, i, '1');
				reducedList = ReduceDiagnosticsList (reducedList, bit, i);
			}

			return Convert.ToInt32 (reducedList.First (), 2);
		}

		public static int CalculateCO2ScrubberRating (List<string> diagnosticData)
		{
			var diagnosticDataLength = diagnosticData.First ().Length;
			var reducedList = new List<string> (diagnosticData);
			for (int i = 0; i < diagnosticDataLength; i++) {
				var bit = FindLeastCommonBit (reducedList, i, '0');
				reducedList = ReduceDiagnosticsList (reducedList, bit, i);
				if (reducedList.Count == 1)
					break;
			}

			return Convert.ToInt32 (reducedList.First (), 2);
		}

		public static int CalculateLifeSupportRate ((int OxygenRate, int CO2Rate) rates)
		{
			return rates.OxygenRate * rates.CO2Rate;
		}

		static List<string> ReduceDiagnosticsList (List<string> data, char bit, int position)
		{
			return data.Where (x => x[position] == bit).ToList ();
		}

		static char FindMostCommonBit (List<string> diagnosticData, int position, char defaultBit)
		{
			var (zeros, ones) = FindZeroAndOneCount (diagnosticData, position);

			if (ones == zeros)
				return defaultBit;

			return (ones > zeros) ? '1' : '0';
		}

		static char FindLeastCommonBit (List<string> diagnosticData, int position, char defaultBit)
		{
			var (zeros, ones) = FindZeroAndOneCount (diagnosticData, position);

			if (ones == zeros)
				return defaultBit;
			if (zeros < ones)
				return '0';

			return '1';
		}

		static (int zeros, int ones) FindZeroAndOneCount (List<string> diagnosticData, int position)
		{
			int oneCount = 0;
			int zeroCount = 0;

			foreach (var diagnostic in diagnosticData) {
				if (diagnostic[position] == '1')
					oneCount++;
				else
					zeroCount++;
			}

			return (zeroCount, oneCount);
		}
	}
}