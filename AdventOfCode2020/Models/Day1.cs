namespace AdventOfCode2020.Models
{
	public class Day1 : DayBase
	{
		public override string Day => "1";

		public Day1(string cookie) : base(cookie)
		{
		}

		public override string Level1()
		{
			for (int i = 0; i < Input.Length; i++)
			{
				for (int j = 0; j < Input.Length; j++)
				{
					if (i == 0)
						continue;

					var entryOne = int.Parse(Input[i]);	
					var entryTwo = int.Parse(Input[j]);
					if (entryOne + entryTwo == 2020)
					{
						return (entryOne * entryTwo).ToString();
					}
				}
			}
			return default;
		}

		public override string Level2()
		{
			for (int i = 0; i < Input.Length; i++)
			{
				for (int j = 0; j < Input.Length; j++)
				{
					for (int k = 0; k < Input.Length; k++)
					{
						if (i == j || i == k || j == k)
							continue;

						var entryOne = int.Parse(Input[i]);
						var entryTwo = int.Parse(Input[j]);
						var entryThree = int.Parse(Input[k]);
						if (entryOne + entryTwo + entryThree == 2020)
						{
							return (entryOne * entryTwo * entryThree).ToString();
						}
					}
				}
			}
			return default;
		}
	}
}
