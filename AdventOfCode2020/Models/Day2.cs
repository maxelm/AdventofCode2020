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
			int validPasswords = 0;
			foreach (var item in Input)
			{
				int min = int.Parse(Regex.Match(item, @"\d+-+\d*").Groups[0].Value.Split("-")[0]);
				int max = int.Parse(Regex.Match(item, @"\d+-+\d*").Groups[0].Value.Split("-")[1]);
				char reqChar = Regex.Match(item, @"[a-z]+:").Groups[0].Value[0];
				string password = Regex.Match(item, @"([a-z])*$").Groups[0].Value;

				int matchedChars = 0;
				foreach (var character in password)
				{
					if (reqChar == character)
						matchedChars++;
				}
				if (matchedChars >= min && matchedChars <= max)
					validPasswords++;
			}
			return validPasswords.ToString();
		}

		public override string Level2()
		{
			int validPasswords = 0;
			foreach (var item in Input)
			{
				var first = int.Parse(Regex.Match(item, @"\d+-+\d*").Groups[0].Value.Split("-")[0]) - 1;
				var second = int.Parse(Regex.Match(item, @"\d+-+\d*").Groups[0].Value.Split("-")[1]) - 1;
				var reqChar = Regex.Match(item, @"[a-z]+:").Groups[0].Value[0];
				var password = Regex.Match(item, @"([a-z])*$").Groups[0].Value;

				var validCharPlacement = 0;
				for (int i = 0; i < password.Length; i++)
				{
					if ((i == first || i == second) && password[i] == reqChar)
						validCharPlacement++;
				}
				if (validCharPlacement == 1)
					validPasswords++;
			}
			return validPasswords.ToString();
		}

		// @"(\d+)-(\d+)\s(\w):\s(\w*)"
	}
}
