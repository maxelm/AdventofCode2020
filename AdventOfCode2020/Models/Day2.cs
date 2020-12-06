using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Models
{
	public class Day2 : DayBase
	{
		public Day2(string cookie) : base(cookie)
		{
		}

		public override int Day => 2;

		public override string Level1()
		{
			int counter = 0;
			foreach (var line in Input)
			{
				var entry = GetEntry(line);
				var occurences = entry.Password.ToCharArray().Count(x => x == entry.Target);
				if (occurences >= entry.Min && occurences <= entry.Max)
					counter++;
			}
			return counter.ToString();
		}

		public override string Level2()
		{
			int counter = 0;
			foreach (var line in Input)
			{
				var entry = GetEntry(line);
				if (IsValidEntry(entry))
				{
					counter++;
				}
			}
			return counter.ToString();
		}

		private static bool IsValidEntry(Entry entry)
		{
			return (entry.Password[entry.Min - 1] == entry.Target) ^ (entry.Password[entry.Max - 1] == entry.Target);
		}

		private static Entry GetEntry(string input)
		{
			var pattern = @"(\d+)-(\d+)\s(\w):\s(\w*)";
			var regex = new Regex(pattern, RegexOptions.IgnoreCase);
			var match = regex.Match(input);
			if (match.Success)
			{
				return new Entry(Convert.ToInt32(match.Groups[1].Value), Convert.ToInt32(match.Groups[2].Value), Convert.ToChar(match.Groups[3].Value), match.Groups[4].Value);
			}
			return null;
		}
		
		private record Entry(int Min, int Max, char Target, string Password);
	}
}
