namespace AdventOfCode2021
{
    public static class Day1
    {

		public static int FindNumberOfIncreasedDepths (List<int> measurements)
		{
			int prev = 0;
			int count = 0;
			measurements.ForEach (m => {
				if (m > prev)
					count++;
				prev = m;
			});
			return count;
		}

		public static int FindNumberOfIncreasedDepthsSlidingWindow (List<int> measurements)
		{
			return FindNumberOfIncreasedDepths (BuildSlidingWindowList (measurements));
		}

		static List<int> BuildSlidingWindowList (List<int> measurements)
		{
			var measurementSums = new List<int> ();
			var start = 0;
			var end = 3;
			while (end < measurements.Count)
				measurementSums.Add (measurements.Take (start++..end++).Sum ());

			return measurementSums;
		}
    }
}