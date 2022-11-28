namespace AdventOfCode2021
{
    public static  class Day2
    {
		public static (int horizontalPosition, int depth) CalculateSubPostion (List<KeyValuePair<string, int>> directions)
		{
			int depth = 0;
			int horizontalPosition = 0;

			foreach (var direction in directions) {
				switch (direction.Key) {
				case "forward":
					horizontalPosition += direction.Value;
					break;
				case "down":
					depth += direction.Value;
					break;
				case "up":
					depth -= direction.Value;
					break;
				}
			}

			return (horizontalPosition, depth);
		}

		public static (int horizontalPosition, int depth) CalculateSubPositionPart2 (List<KeyValuePair<string, int>> directions)
		{
			int depth = 0;
			int horizontalPosition = 0;
			int aim = 0;

			foreach (var direction in directions) {
				switch (direction.Key) {
				case "forward":
					horizontalPosition += direction.Value;
					depth += (aim * direction.Value);
					break;
				case "down":
					aim += direction.Value;
					break;
				case "up":
					aim -= direction.Value;
					break;
				}
			}

			return (horizontalPosition, depth);

		}

		public static int GetFinalValue ((int horizontalPosition, int depth) result)
		{
			return result.horizontalPosition * result.depth;
		}
	}
}