

using System.ComponentModel.Design;

namespace AdventOfCode2021
{

	public class FloorMap
	{
		readonly int[,] map;
		public int Size { get; } = 0;

		public FloorMap (int mapSize)
		{
			Size = mapSize;
			map = new int[Size,Size];
		}

		public void AddLineToMap ((int x, int y) one, (int x, int y) two)
		{
			if (one.x == two.x) {
				int first, second;
				if (one.y < two.y) {
					first = one.y;
					second = two.y;
				} else {
					first = two.y;
					second = one.y;
				}
				for (int j = first; j <= second; j++) {
					map[one.x, j] += 1;
				}
			}

			if (one.y == two.y) {
				int first, second;
				if (one.x < two.x) {
					first = one.x;
					second = two.x;
				} else {
					first = two.x;
					second = one.x;
				}
				for (int i = first; i <= second; i++) {
					map[i, one.y] += 1;
				}
			}

			if (Math.Abs (one.x - two.x) == Math.Abs (one.y - two.y)) {
				var distance = Math.Abs (one.x - two.x);

				if (one.x < two.x && one.y < two.y) {
					//++
					for (int i = 0; i <= distance; i++) {
						map[one.x++, one.y++] += 1;
					}
				}

				else if (one.x < two.x && one.y > two.y) {
					//+-
					for (int i = 0; i <= distance; i++) {
						map[one.x++, one.y--] += 1;
					}
				}

				else if (one.x > two.x && one.y < two.y) {
					//-+
					for (int i = 0; i <= distance; i++) {
						map[one.x--, one.y++] += 1;
					}
				}

				else if (one.x > two.x && one.y > two.y) {
					//--
					for (int i = 0; i <= distance; i++) {
						map[one.x--, one.y--] += 1;
					}

				}
			}
		}

		public int NumberOfOverlappingSegments ()
		{
			int overlaps = 0;
			for (int x = 0; x < Size; x++) {
				for (int y = 0; y < Size; y++) {
					if (map [x,y] > 1)
						overlaps++;
				}
			}

			return overlaps;
		}

		public void PrintMap ()
		{
			for (int y = 0; y < Size; y++) {
				for (int x = 0; x < Size; x++) {
					if (map[x, y] != 0)
						Console.Write ($" {map[x, y]} ");
					else
						Console.Write (" . ");
				}
				Console.WriteLine ();
			}
		}
	}

	public static class Day5
	{
		public static int Part1 (int floorMapSize, List<string> lines)
		{

			var floorMap = new FloorMap (floorMapSize);

			foreach (var line in lines) {
				var coords = line.Split (',').Select (int.Parse).ToList ();
				floorMap.AddLineToMap ((coords[0], coords[1]), (coords[2], coords[3]));
			}

			floorMap.PrintMap ();

			return floorMap.NumberOfOverlappingSegments ();
		}
	}
}