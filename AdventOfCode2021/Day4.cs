
namespace AdventOfCode2021
{
	public class Board
	{
		readonly int[,] board = new int[5, 5];
		public List<int> Guesses { get; private set; } = new();

		public bool Won { get; private set; }

		public Board (List<int> inputBoard)
		{
			int index = 0;
			for (int i = 0; i < 5; i++) {
				for (int j = 0; j < 5; j++) {
					board[i, j] = inputBoard[index++];
				}
			}
		}

		public void MakeGuess (int guess)
		{
			Guesses.Add (guess);
		}

		public bool IsWinner ()
		{
			Won = CheckHorizontalWinner () || CheckVerticalWinner ();
			return Won;
		}

		public int LastGuess () => Guesses.Last ();

		bool CheckHorizontalWinner ()
		{
			for (int i = 0; i < 5; i++) {
				int count = 0;
				for (int j = 0; j < 5; j++) {
					if (Guesses.Contains (board[i, j]))
						count++;
				}
				if (count == 5)
					return true;
			}

			return false;
		}

		public bool CheckVerticalWinner ()
		{
			for (int i = 0; i < 5; i++) {
				int count = 0;
				for (int j = 0; j < 5; j++) {
					if (Guesses.Contains (board[j, i]))
						count++;
				}
				if (count == 5)
					return true;
			}

			return false;
		}

		public List<int> GetUnmarked ()
		{
			var unmarked = new List<int> ();
			for (int i = 0; i < 5; i++) {
				for (int j = 0; j < 5; j++) {
					if (!Guesses.Contains (board[i, j]))
						unmarked.Add (board[i, j]);
				}
			}
			return unmarked;
		}
	}

	public static class Day4
	{
		public static Board GetFirstWinningBoard (List<int> guesses, List<Board> boards)
		{
			foreach (int guess in guesses) {
				foreach (var board in boards) {
					board.MakeGuess (guess);
					if (board.IsWinner ())
						return board;
				}
			}

			return null;
		}

		public static Board GetLastWinningBoard (List<int> guesses, List<Board> boards)
		{
			foreach (int guess in guesses) {
				foreach (var board in boards) {
					if (board.IsWinner ())
						continue;
					board.MakeGuess(guess);
				}
			}

			return boards.MaxBy (x => x.Guesses.Count);
		}

		public static int ComputeWinningBoard (Board board)
		{
			var unmarked = board.GetUnmarked ();
			var sum = unmarked.Sum ();
			var last = board.LastGuess ();

			return sum * last;
		}
	}
}