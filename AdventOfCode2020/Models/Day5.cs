using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Models
{
	public class Day5 : DayBase
	{
		public Day5(string cookie) : base(cookie)
		{
		}

		public override int Day => 5;

		public override void Initialize()
		{
			GetInput();
		}

		public override string Level1()
		{
			int highestId = 0;
			foreach (var boardingPass in Input)
			{
				int id = GetSeatId(boardingPass.Substring(0, 7), boardingPass.Substring(7, 3));
				if (id > highestId)
				{
					highestId = id;
				}
			}
			return highestId.ToString();
		}

		private int GetSeatId(string row, string column)
		{
			var rowNumber = GetIndex(0, 127, row, 'F');
			var columnNumber = GetIndex(0, 7, column, 'L');
			return Convert.ToInt32(rowNumber * 8 + columnNumber);
		}

		private static double GetIndex(double start, double end, string input, char comparer)
		{
			foreach (char letter in input)
			{
				if (letter == comparer)
				{
					end = Math.Round((start + end) / 2, MidpointRounding.ToZero);
				}
				else
				{
					start = Math.Round((start + end) / 2, MidpointRounding.AwayFromZero);
				}
			}
			return start;
		}

		public override string Level2()
		{
			var seats = new List<int>();
			foreach (var boardingPass in Input)
			{
				seats.Add(GetSeatId(boardingPass.Substring(0, 7), boardingPass.Substring(7, 3)));
			}

			var orderedSeats = seats.OrderBy(x => x).ToArray();
			var mySeatId = orderedSeats.Min();
			for (int i = 0; i < orderedSeats.Length; i++)
			{
				if (mySeatId == orderedSeats[i])
				{
					mySeatId++;
				}
				else
				{
					break;
				}
			}

			return mySeatId.ToString();
		}
	}
}
