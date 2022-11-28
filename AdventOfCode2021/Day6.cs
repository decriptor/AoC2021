
namespace AdventOfCode2021
{
	public static class Day6
	{
		public class LanternFish
		{
			public int Interval { get; private set; }
			public int Initial { get; } = 6;

			public LanternFish (int interval)
			{
				Interval = interval;
			}

			public bool Bump ()
			{
				if (Interval == 0) {
					Interval = Initial;
					return true;
				}

				Interval--;
				return false;
			}

			public override string ToString () => $"Fish: {Interval} of {Initial}";
		}

		static readonly List<LanternFish> ListOFish = new ();
		public static long Part1 (List<int> initialFish, int numberOfDays)
		{
			ListOFish.Clear ();
			initialFish.ForEach (fish => ListOFish.Add (new LanternFish (fish)));

			Console.Write ("Initial state:");
			ListOFish.ForEach (fish => Console.Write ($" {fish.Interval},"));
			Console.WriteLine ();


			for (int i = 1; i <= numberOfDays; i++) {
				InterateDay (ListOFish);
				PrintFishes (ListOFish, i);
			}

			return ListOFish.Count;
		}

		static void PrintFishes (List<LanternFish> listOFish, int day)
		{
			Console.Write ($"After  {day} days: ");
			listOFish.ForEach (fish => { Console.Write ($" {fish.Interval},"); });
			Console.WriteLine ();
		}

		static void InterateDay (List<LanternFish> listOFish)
		{
			var fishToAdd = new List<LanternFish> ();

			Parallel.ForEach (listOFish, fish => {
				if (fish.Bump ())
					fishToAdd.Add (new LanternFish (8));
			});

			listOFish.AddRange (fishToAdd);
		}
	}
}