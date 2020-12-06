using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Models
{
	public class Day3 : DayBase
	{
		public Day3(string cookie) : base(cookie)
		{
		}

		public override int Day => 3;

		public override string Level1()
		{
			return GetTreesHitForSlope(new Slope(3, 1)).ToString();
		}

		public override string Level2()
		{
			var slopes = new List<Slope> { new Slope(1, 1), new Slope(3, 1), new Slope(5, 1), new Slope(7, 1), new Slope(1,2) };
			return slopes.Aggregate((long)0, (value, next) => value * GetTreesHitForSlope(next)).ToString();
		}

		private long GetTreesHitForSlope(Slope slope)
		{
			int counter = 0;
			int columnIndex = 0;
			for (int i = 0; i < Input.Length; i += slope.Down)
			{
				if (Input[i][columnIndex] == '#')
					counter++;

				columnIndex = (columnIndex + slope.Right) % Input[i].Length;
			}
			return counter;
		}

		private record Slope(int Right, int Down);
	}
}
