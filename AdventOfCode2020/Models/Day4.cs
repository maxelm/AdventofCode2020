using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Models
{
	public class Day4 : DayBase
	{
		public Day4(string cookie) : base(cookie)
		{
		}

		public override int Day => 4;

		public override void Initialize()
		{
			GetInput(true);
		}

		public override string Level1()
		{
			int counter = 0;
			var fields = new Dictionary<string, string>();
			foreach (var entries in Input)
			{
				if (string.IsNullOrWhiteSpace(entries))
				{
					if (ValidFields(fields))
					{
						counter++;
					}
					fields = new Dictionary<string, string>();
					continue;
				}
				ParsePassportFields(entries, fields);
			}
			return counter.ToString();
		}

		public override string Level2()
		{
			int counter = 0;
			var fields = new Dictionary<string, string>();
			foreach (var entries in Input)
			{
				if (string.IsNullOrWhiteSpace(entries))
				{
					if (ValidFields(fields) && ValidFieldValues(fields))
					{
						counter++;
					}

					fields = new Dictionary<string, string>();
					continue;
				}
				ParsePassportFields(entries, fields);
			}
			return counter.ToString();
		}

		private static void ParsePassportFields(string input, Dictionary<string, string> fields)
		{
			var fieldsArray = input.Split(" ");
			var pattern = @"(\w{3}):([^\n]*)";
			foreach (var field in fieldsArray)
			{
				var regex = new Regex(pattern);
				var match = regex.Match(field);
				if (match.Success)
				{
					fields.Add(match.Groups[1].Value, match.Groups[2].Value);
				}
				else
				{
					throw new ArgumentException("No Christmas for you!");
				}
			}
		}

		private static bool ValidFields(Dictionary<string, string> fields)
		{
			return (fields.Count == 8) || (fields.Count == 7 && !fields.ContainsKey("cid"));
		}

		private static bool ValidFieldValues(Dictionary<string, string> fields)
		{
			var isValid = true;
			foreach (var field in fields)
			{
				switch (field.Key)
				{
					case "byr":
						var byr = int.Parse(field.Value);
						isValid = byr >= 1920 && byr <= 2002 && isValid;
						break;
					case "iyr":
						var iyr = int.Parse(field.Value);
						isValid = iyr >= 2010 && iyr <= 2020 && isValid;
						break;
					case "eyr":
						var eyr = int.Parse(field.Value);
						isValid = eyr >= 2020 && eyr <= 2030 && isValid;
						break;
					case "hgt":
						var measurement = field.Value.Substring(field.Value.Length - 2, 2);
						var value = field.Value.Substring(0, field.Value.Length - 2);
						switch (measurement)
						{
							case "cm":
								var cm = int.Parse(value);
								isValid = cm >= 150 && cm <= 193 && isValid;
								break;
							case "in":
								var inc = int.Parse(value);
								isValid = inc >= 59 && inc <= 76 && isValid;
								break;
							default:
								isValid = false;
								break;
						}
						break;
					case "hcl":
						var hclRegex = new Regex(@"#([a-f0-9]){6}");
						var match = hclRegex.Match(field.Value);
						isValid = match.Success && isValid;
						break;
					case "ecl":
						var eclRegex = new Regex(@"(amb|blu|brn|gry|grn|hzl|oth)");
						var eclMatch = eclRegex.Match(field.Value);
						isValid = eclMatch.Success && isValid;
						break;
					case "pid":
						var pidRegex = new Regex(@"^\d{9}$");
						var pidMatch = pidRegex.Match(field.Value);
						isValid = pidMatch.Success && isValid;
						break;
					case "cid": break;
					default:
						throw new ArgumentException("No Christmas for you!");
				}
			}
			return isValid;
		}
	}
}