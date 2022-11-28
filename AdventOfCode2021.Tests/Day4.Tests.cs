using System.Collections.Generic;

using NUnit.Framework;

using Shouldly;

namespace AdventOfCode2021.Tests
{
	public class Day4Tests
	{
		List<int> testDataGuesses = new () {
			7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1
		};

		List<Board> testDataBoards = new () {
			new Board (new List<int> {
				22, 13, 17, 11,  0,
				 8,  2, 23,  4, 24,
				21,  9, 14, 16,  7,
				 6, 10,  3, 18,  5,
				 1, 12, 20, 15, 19}),
			new Board(new List<int> {
				 3, 15,  0,  2, 22,
				 9, 18, 13, 17,  5,
				19,  8,  7, 25, 23,
				20, 11, 10, 24,  4,
				14, 21, 16, 12,  6 }),
			new Board(new List<int>{
				14, 21, 17, 24,  4,
				10, 16, 15,  9, 19,
				18,  8, 23, 26, 20,
				22, 11, 13,  6,  5,
				 2,  0, 12,  3,  7 })
		};

		[Test]
		public void Part1 ()
		{
			var winningBoard = Day4.GetFirstWinningBoard (testDataGuesses, testDataBoards);
			var winningScore = Day4.ComputeWinningBoard (winningBoard);

			winningScore.ShouldBe (4512);

			var winningBoardReal = Day4.GetFirstWinningBoard (Day4Data.Guesses, Day4Data.Boards);
			var winningScoreReal = Day4.ComputeWinningBoard (winningBoardReal);

			winningScoreReal.ShouldBe (16716);
		}

		[Test]
		public void Part2 ()
		{
			var lastWinningBoard = Day4.GetLastWinningBoard (testDataGuesses, testDataBoards);
			var lastWinningBoardScore = Day4.ComputeWinningBoard (lastWinningBoard);

			lastWinningBoardScore.ShouldBe (1924);

			var lastWinningBoardReal = Day4.GetLastWinningBoard (Day4Data.Guesses, Day4Data.Boards);
			var lastWinningBoardScoreReal = Day4.ComputeWinningBoard (lastWinningBoardReal);

			lastWinningBoardScoreReal.ShouldBe (4880);
			// 4512 too low
		}
	}
}