using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Models
{
	public class Day6 : DayBase
	{
		public Day6(string cookie) : base(cookie)
		{
		}

		public override int Day => 6;

		public override void Initialize()
		{
			GetInput(true);
		}

		public override string Level1()
		{
			var counter = 0;
			var groupAnswers = new Dictionary<char, int>();
			foreach (var form in Input)
			{
				if (string.IsNullOrWhiteSpace(form))
				{
					counter += groupAnswers.Values.Aggregate(0, (acc, value) => acc + value);
					groupAnswers = new Dictionary<char, int>();
					continue;
				}

				foreach (char answer in form)
				{
					if (!groupAnswers.TryGetValue(answer, out int count))
					{
						groupAnswers.Add(answer, 1);
					}
				}
			}

			return counter.ToString();
		}

		public override string Level2()
		{
			var counter = 0;
			var groupMemberCount = 0;
			var groupAnswers = new Dictionary<char, int>();
			foreach (var form in Input)
			{
				if (string.IsNullOrWhiteSpace(form))
				{
					counter += groupAnswers.Values.Where(x => x == groupMemberCount).Count();
					groupAnswers = new Dictionary<char, int>();
					groupMemberCount = 0;
					continue;
				}

				groupMemberCount++;
				foreach (char answer in form)
				{
					if (groupAnswers.TryGetValue(answer, out int count))
					{
						groupAnswers[answer] = count + 1;
					}
					else
					{
						groupAnswers.Add(answer, 1);
					}
				}
			}

			return counter.ToString();
		}
	}
}
